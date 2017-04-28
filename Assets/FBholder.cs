using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class FBholder : MonoBehaviour {

	public GameObject UIFBIsLoggedIn;
	public GameObject UIFBNotLoggedIn;
	public GameObject UIFBAvatar;
	public GameObject UIFBUserName;
	
	private List<object> scoresList = null;

	public GameObject ScoreEntryPanel;
	public GameObject ScoreScrollList;

    GameObject ObjGameOver;
    highScore HighScore;

	private Dictionary<string, string> profile = null;

	void Awake()
	{
		FB.Init (SetInit, OnHideUnity);

        if (FB.IsLoggedIn)
        {
            Debug.Log("FB login worked!");
            DealWithFBMenus(true);
            QueryScores();
        }
        else
        {
            Debug.Log("FB Login fail");
            DealWithFBMenus(false);
        }
        if (SceneManager.GetActiveScene().name == "Game")
        {
            ObjGameOver = GameObject.Find("GameOver");
            HighScore = ObjGameOver.GetComponent<highScore>();
        }
	}

	private void SetInit()
	{
		Debug.Log ("FB Init done.");

		if(FB.IsLoggedIn)
		{
			DealWithFBMenus(true);
			Debug.Log ("FB Logged In");
		}else{
			DealWithFBMenus(false);
		}

	}

	private void OnHideUnity(bool isGameShown)
	{

		if(!isGameShown)
		{
			Time.timeScale = 0;
		}else{
			Time.timeScale = 1;
		}

	}

	public void FBlogin()
	{
        FB.Login("email,publish_actions,user_friends", AuthCallback);
	}

    public void FBlogout()
    {
        FB.Logout();
        DealWithFBMenus(false);
        try
        {
            ScoreScrollList.SetActive(false);
        }
        catch (System.Exception)
        {
      
        }
    }



	void AuthCallback(FBResult result)
	{
		if(FB.IsLoggedIn){
			Debug.Log ("FB login worked!");
			DealWithFBMenus(true);
            QueryScores();
		}else{
			Debug.Log ("FB Login fail");
			DealWithFBMenus(false);
		}
	}



	public void DealWithFBMenus(bool isLoggedIn)
	{
		if(isLoggedIn){
			UIFBIsLoggedIn.SetActive (true);
			UIFBNotLoggedIn.SetActive(false);
           
			// get profile picture code
			FB.API (Util.GetPictureURL("me", 128, 128), Facebook.HttpMethod.GET, DealWithProfilePicture);
			FB.API ("/me?fields=id,first_name", Facebook.HttpMethod.GET, DealWithUserName);
			// get username code
            ScoreScrollList.SetActive(true);
		}else{
			UIFBIsLoggedIn.SetActive (false);
			UIFBNotLoggedIn.SetActive(true);
            try
            {
                ScoreScrollList.SetActive(false);
            }
            catch (System.Exception)
            {
                
                
            }
		}
	}

  

	void DealWithProfilePicture(FBResult result)
	{

		if(result.Error != null)
		{
			Debug.Log ("problem with getting profile picture");

			FB.API (Util.GetPictureURL("me", 128, 128), Facebook.HttpMethod.GET, DealWithProfilePicture);
			return;
		}

		Image UserAvatar = UIFBAvatar.GetComponent<Image>();
		UserAvatar.sprite = Sprite.Create (result.Texture, new Rect(0,0,128,128), new Vector2(0,0));

	}

	void DealWithUserName(FBResult result)
	{
		if(result.Error != null)
		{
			Debug.Log ("problem with getting profile picture");
			
			FB.API ("/me?fields=id,first_name", Facebook.HttpMethod.GET, DealWithUserName);
			return;
		}

		profile = Util.DeserializeJSONProfile(result.Text);

		Text UserMsg = UIFBUserName.GetComponent<Text>();

		UserMsg.text = "Hello, " + profile["first_name"];


	}

	public void ShareWithFriends()
	{
        if (FB.IsLoggedIn){
		FB.Feed (
            linkCaption: "I scored " + HighScore.score.ToString() +"!",
			picture: "http://greyzoned.com/images/evilelf2_icon.png",
			linkName: "Gary Gravity",
			link: "http://apps.facebook.com/" + FB.AppId + "/?challenge_brag=" + (FB.IsLoggedIn ? FB.UserId : "guest")
			);
        }
        else
        {
            FBlogin();
        }
	}

	public void InviteFriends()
	{
		FB.AppRequest(
			message: "This game is awesome, join me. now.",
			title: "Invite your friends to join you"
			);
	}

	// All Scores API related Things

    public void QueryScores()
    {

        if (FB.IsLoggedIn)
        {
            FB.API("/app/scores?fields=score,user.limit(30)", Facebook.HttpMethod.GET, ScoresCallback);
        }
    }

	private void ScoresCallback(FBResult result)
	{
		Debug.Log ("Scores callback: " + result.Text);


		scoresList = Util.DeserializeScores (result.Text);

		foreach (Transform child in ScoreScrollList.transform) 
		{
			GameObject.Destroy (child.gameObject);
		}

		foreach (object score in scoresList) 
		{

			var entry = (Dictionary<string,object>) score;
			var user = (Dictionary<string,object>) entry["user"];




			GameObject ScorePanel;
			ScorePanel = Instantiate (ScoreEntryPanel) as GameObject;
			ScorePanel.transform.parent = ScoreScrollList.transform;

			Transform ThisScoreName = ScorePanel.transform.Find ("FriendName");
			Transform ThisScoreScore = ScorePanel.transform.Find ("FriendScore");
			Text ScoreName = ThisScoreName.GetComponent<Text>();
			Text ScoreScore = ThisScoreScore.GetComponent<Text>();

			ScoreName.text = user["name"].ToString();
			ScoreScore.text = entry["score"].ToString();

			Transform TheUserAvatar = ScorePanel.transform.Find ("FriendAvatar");
			Image UserAvatar = TheUserAvatar.GetComponent<Image>();


			FB.API (Util.GetPictureURL(user["id"].ToString (), 128,128), Facebook.HttpMethod.GET, delegate(FBResult pictureResult){

				if(pictureResult.Error != null) // if there was an error
				{
					Debug.Log (pictureResult.Error);
				}
				else // if everything was fine
				{
					UserAvatar.sprite = Sprite.Create (pictureResult.Texture, new Rect(0,0,128,128), new Vector2(0,0));
				}

			});



		}


	}

	public void SetScore()
	{
		var scoreData = new Dictionary<string,string> ();
		scoreData ["score"] = Random.Range (10, 200).ToString ();
		FB.API ("/me/scores", Facebook.HttpMethod.POST, delegate(FBResult result) {
			Debug.Log ("Score submit result: " + result.Text);
		}, scoreData);
	}

    void OnApplicationQuit()
    {
        FBlogout();
    }
 

    

}






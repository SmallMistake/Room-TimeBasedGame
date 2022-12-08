using MoreMountains.Tools;
using MoreMountains.TopDownEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveSystem
{
    /// <summary>
	/// The ProgressManager class acts as a way to implement progress management in the game.
	/// </summary>
    public class ProgressManager : MMSingleton<ProgressManager>
    {
		public GameProgress cachedProgress;

        protected const string _saveFolderName = "GameProgressData";
        protected const string _saveFileName = "Progress.data";

		private static GameObject instance; //this is used to ensure there are not multiple gameObjects. If it is already set destroy the new one

		void Awake()
		{
			DontDestroyOnLoad(gameObject);
			if (instance == null)
            {
				instance = gameObject;
				base.Awake();
                try
                {
					LoadSavedProgress();
                }
                catch(Exception e)
                {
					//TODO Imrpove Debugger
					Debug.Log(e);
				}
			}
			else
				Destroy(gameObject); //If a version of this class already exists Destroy self
		}

		//TODO Save Level On Completion
		/// <summary>
		/// When a level is completed, we update our progress
		/// </summary>
		/*
		protected virtual void LevelComplete()
		{
			for (int i = 0; i < Scenes.Length; i++)
			{
				if (Scenes[i].SceneName == SceneManager.GetActiveScene().name)
				{
					Scenes[i].LevelComplete = true;
					Scenes[i].LevelUnlocked = true;
					if (i < Scenes.Length - 1)
					{
						Scenes[i + 1].LevelUnlocked = true;
					}
				}
			}
		}
		*/

		public void increaseAttribute(int amountToIncrease, GameProgressAttributes attributeToIncrease)
        {
            switch (attributeToIncrease)
            {
				case GameProgressAttributes.developmentProgress:
					cachedProgress.developmentProgress += amountToIncrease;
						break;
			}
        }

		/// <summary>
		/// Saves the progress to a file
		/// </summary>
		public virtual void SaveProgress()
		{
			GameProgress progress = new GameProgress();
			progress.Days = cachedProgress.Days;
			progress.currentDay = cachedProgress.currentDay;
			progress.playerData = cachedProgress.playerData;

			MMSaveLoadManager.Save(progress, _saveFileName, _saveFolderName);
		}

		/// <summary>
		/// A test method to create a test save file at any time from the inspector
		/// </summary>
		public void CreateSaveGame()
		{
			SaveProgress();
		}

		/// <summary>
		/// Loads the saved progress into memory
		/// </summary>
		public virtual void LoadSavedProgress()
		{
			GameProgress progress = (GameProgress)MMSaveLoadManager.Load(typeof(GameProgress), _saveFileName, _saveFolderName);
			if (progress != null)
			{

				//GameManager.Instance.MaximumLives = progress.MaximumLives;
				cachedProgress.Days = progress.Days;
				cachedProgress.currentDay = progress.currentDay;
				cachedProgress.playerData = progress.playerData;
			}
			else
			{
			}
		}
	}
}
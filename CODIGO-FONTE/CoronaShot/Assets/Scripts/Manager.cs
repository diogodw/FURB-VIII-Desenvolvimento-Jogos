using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : Singleton<Manager> {

      public bool started = false; 
      public bool paused = false; 
      
      public int score = 0;
      public int wave = 1;

      public void Start()
      {
            started = true;
            paused = false;
            wave = 1;
            score = 0;
      }

      public void AddScore(int points) 
      {
            score += points;
            ChangeScoreText();

            int newWave = (int)(score / 100) + 1;

            if (wave != newWave) 
            {
                  wave = newWave;
                  ChangeAtilaMessageByWave();
                  if (wave <= 16) ChangeBackground();
            }
      }

      void ChangeScoreText() 
      {
            GameObject.Find("ScoreValue").GetComponent<Text>().text = score.ToString("0000");
            GameObject.Find("WaveValue").GetComponent<Text>().text = wave.ToString("000");
      }

      void ChangeBackground() 
      {
            GameObject.Find("Background").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite> ("Backgrounds/Game/background" + (((int) wave / 4) + 1));
      }

      public void Pause()
      {
            paused = true;
            Time.timeScale = 0;
            SceneManager.LoadScene(0, LoadSceneMode.Additive);
      }

      public void Resume()
      {
            paused = false;
            SceneManager.UnloadSceneAsync(0);
            Time.timeScale = 1; 
      }

      void ChangeAtilaMessageByWave()
      {
            switch (wave)
            {
                case 1: 
                  ChangeAtilaMessage("Elimine os virus com o alcool gel");
                  break;
                case 2: 
                  ChangeAtilaMessage("Os virus verdes sao mais resistentes");
                  break;
                case 3: 
                  ChangeAtilaMessage("Use a mascara para sua protecao");
                  break;
                case 4: 
                  ChangeAtilaMessage("O SUS salva vidas");
                  break;
                case 5: 
                  ChangeAtilaMessage("A cloroquina nao e um tratamento eficaz");
                  break;
                case 12: 
                  ChangeAtilaMessage("Evite ambientes fechados");
                  break;
                case 18: 
                  ChangeAtilaMessage("Evite aglomeracoes");
                  break;
                case 25: 
                  ChangeAtilaMessage("Nao espalhe fake news");
                  break;
                case 31: 
                  ChangeAtilaMessage("Confie em estudos cientificos");
                  break;
                
                default: 
                  break;
            }
      }

      public void ChangeAtilaMessage(string message)
      {
            GameObject.Find("AtilaText").GetComponent<Text>().text = message;
      }

 }

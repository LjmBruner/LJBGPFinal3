using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class MainMenuTests
{
    // A Test behaves as an ordinary method
    [Test]
    public void MainMenuTestsSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator MainMenuTestsWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }

    [UnityTest]
    public IEnumerator PlayButtonLoadsGameScene()
    {
        SceneManager.LoadScene("Intro");
        yield return new WaitForSeconds(0.1f);

        Button playButton = GameObject.Find("PlayButton").GetComponent<Button>();

        playButton.onClick.Invoke();

        yield return new WaitForSeconds(0.1f);

        Assert.That(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game"));
    }

    [UnityTest]
    public IEnumerator StopButtonStopsPlay()
    {
        SceneManager.LoadScene("Game");
        yield return new WaitForSeconds(0.1f);

        Button stopButton = GameObject.Find("StopButton").GetComponent<Button>();

        stopButton.onClick.Invoke();

        yield return new WaitForSeconds(0.1f);

        Assert.That(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Exit"));
    }

    [UnityTest]
    public IEnumerator PlayAgainButtonRestartsGame()
    {
        SceneManager.LoadScene("Exit");
        yield return new WaitForSeconds(0.1f);

        Button restartButton = GameObject.Find("PlayAgainButton").GetComponent<Button>();

        restartButton.onClick.Invoke();

        yield return new WaitForSeconds(0.1f);

        Assert.That(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Intro"));
    }

    [UnityTest]
    public IEnumerator PlayerNameShownInGame()
    {
        SceneManager.LoadScene("Game");
        yield return new WaitForSeconds(0.1f);

        Text nameText = GameObject.Find("NameText").GetComponent<Text>();

        Assert.That(nameText.text == Scoring.playerName);

    }

    [UnityTest]
    public IEnumerator NameFromIntroShowsInGameScene()
    {
        SceneManager.LoadScene("Intro");
        yield return new WaitForSeconds(0.1f);
        Text introNameText = GameObject.Find("NameText").GetComponent<Text>();
        SceneManager.LoadScene("Game");
        yield return new WaitForSeconds(0.1f);
        Text gameNameText = GameObject.Find("NameText").GetComponent<Text>();

        Assert.That(introNameText.text == gameNameText.text);
    }

    [UnityTest]
    public IEnumerator DestroyingFiveTargetsStopsGame()
    {
        SceneManager.LoadScene("Game");
        yield return new WaitForSeconds(0.1f);

        GameObject.Destroy(GameObject.Find("CapsuleTarget"));
        GameObject.Destroy(GameObject.Find("CapsuleTarget (1)"));
        GameObject.Destroy(GameObject.Find("CapsuleTarget (2)"));
        GameObject.Destroy(GameObject.Find("CapsuleTarget (3)"));
        GameObject.Destroy(GameObject.Find("CapsuleTarget (4)"));
        yield return new WaitForSeconds(0.1f);

        Assert.That(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Exit"));
    }
}

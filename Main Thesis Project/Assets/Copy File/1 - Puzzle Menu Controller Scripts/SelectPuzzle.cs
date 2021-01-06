using UnityEngine;
using System.Collections;

public class SelectPuzzle : MonoBehaviour {

	[SerializeField]
	private PuzzleGameManager puzzleGameManager;

	[SerializeField]
	private SelectLevel selectLevel;

	[SerializeField]
	private LevelLocker levelLocker;

	[SerializeField]
	private StarsLocker starsLocker;

	[SerializeField]
	private GameObject selectPuzzleMenuPanel, puzzleLevelSelectPanel;

	[SerializeField]
	private Animator selectPuzzleMenuAnim, puzzleLevelSelectAnim;

	private string selectedPuzzle;

    void Start()
    {
        SelectedPuzzle();
    }
    
	public void SelectedPuzzle() {

		starsLocker.DeactivateStars ();

		selectedPuzzle = "Candy Puzzle";

		puzzleGameManager.SetSelectedPuzzle (selectedPuzzle);

		levelLocker.CheckWhichLevelsAreUnlocked (selectedPuzzle);

		selectLevel.SetSelectedPuzzle (selectedPuzzle);

		StartCoroutine (ShowPuzzleLevelSelectMenu ());

	}

	IEnumerator ShowPuzzleLevelSelectMenu() {
		puzzleLevelSelectPanel.SetActive (true);
		selectPuzzleMenuAnim.Play ("SlideOut");
		puzzleLevelSelectAnim.Play ("SlideIn");
		yield return new WaitForSeconds (1f);
		selectPuzzleMenuPanel.SetActive (false);
	}

} // SelectPuzzle


















































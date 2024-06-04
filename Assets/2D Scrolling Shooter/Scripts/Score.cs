using System;
using System.IO;
using UnityEngine;
// 플레이어의 점수를 저장하는데 사용할 데이터 클래스.
// [System.Serializable]을 붙여야 인스펙터에서 필요할 때 노출이 가능.
// 컴포넌트로 추가해줘야 하는 게 아니라면 모노비헤이비어를 굳이 붙이지 않아도 괜찮다.

[System.Serializable]
public class Score
{
    // 퍼블릭 변수로 두면 Json으로 직렬화할 후보가 된다.
    // 컴퓨터 입장에선 직렬화 혹은 퍼블릭을 이용하면 변수를 파일로 빼낼 때 고려할 대상이 된다.
    // 아래를 이용하면 퍼블릭이어도 빼준다.
    // 에디터에 노출도 빼준다.
    // 기능 구현이 급해서 퍼블릭 변수로 쓸 때 사용하면 된다.
    [NonSerialized]

    // 플레이어의 현재 점수 지금은 잘 작동하는지 확인하기 위해 직렬화 필드 안에 넣어놨지만 나중엔 뺄 거다.
    //[SerializeField]
    private int score = 0;

    // 플레이어의 최고 점수 (기록).
    [SerializeField] private int bestScore = 0;

    // 테스트.
    //public string jsonString;

    // 텍스트 UI 참조 변수.
    private TMPro.TextMeshProUGUI scoreText;
    private TMPro.TextMeshProUGUI bestScoreText;

    // 메세지 - 공개 메소드 (인터페이스) - 초기화 함수.
    public void Initialize()
    {
        // PlayerPrefs최고 점수 로드.
        // bestScore = PlayerPrefs.GetInt("BestScore");


        // Json테스트 - 직렬화.
        //jsonString = JsonUtility.ToJson(this);

        // Json 역직렬화.
        // 1. 파일을 불러와 문자열로 읽어오기.
        // 파일을 불러올 때는 항상 예외처리를 해주어야 한다.
        string jsonString = File.ReadAllText("Assets/Score.txt");
        // 2. 불러온 문자열 값을 객체로 복원 (역직렬화).
        bestScore = JsonUtility.FromJson<Score>(jsonString).bestScore;
        // UI 업데이트.
        if (scoreText != null)
        {
            scoreText.text = $"Score : {score}";
        }

        // UI 업데이트.
        if (bestScoreText != null )
        {
            bestScoreText.text = $"BestScore : {bestScore}";
        }
    }


    // 점수 획득 함수.
    public void Add(int gainScore)
    {
        // 점수 누적.
        score += gainScore;

        // UI 업데이트.

        if (scoreText != null)
        {
            scoreText.text = $"Score : {score}";
        }
    


        // 최고 점수인지 판단,
        if (score >= bestScore)
        {
            // 최고 점수와 같거나 높다면 최고 점수 업데이트.
            bestScore = score;

            // 최고 점수를 파일에 기록.

            // 해시테이블 형태로 저장되며, 방대한 데이터가 아니라면 가볍게 사용하기 좋다.
            // 저장할 데이터가 int, float, string으로 치환된다면 저장 가능하다.
            PlayerPrefs.SetInt("BestScore", bestScore);

            // Json으로 기록.
            // 1. 저장할 객체를 Json 문자열로 생성(변환).
            string jsonString = JsonUtility.ToJson(this);
            // 2. 변환한 Json 문자열을 파일로 저장.
            // 2-1. 파일로 저장하려면 상대 경로(저장하려는 위치)와 파일 이름, 확장자를 지정해야 함.
            File.WriteAllText("Assets/Score.txt", jsonString);
            // UI 업데이트.

            if (bestScoreText != null)
            {
                bestScoreText.text = $"BestScore : {bestScore}";
            }
        }
    }

    // 텍스트 UI의 참조 값을 설정하는 함수.
public void SetTextUI(TMPro.TextMeshProUGUI scoreText, TMPro.TextMeshProUGUI bestScoreText)
    {
        this.scoreText = scoreText;
        this.bestScoreText = bestScoreText;
    }
}

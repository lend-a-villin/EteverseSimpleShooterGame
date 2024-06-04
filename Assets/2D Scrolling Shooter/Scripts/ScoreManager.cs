using UnityEngine;
// 점수 관리자 - 컴포넌트로 관리할 스크립트.
public class ScoreManager : MonoBehaviour
{

    // 싱글톤(singleton) - 디자인 패턴.
    // 안 쓸 수 있으면 안 쓰는 게 좋지만 알아두면 유용하다.
    // - 실행 환경에서 1개만 존재해야 하는 제한 사항이 있음.
    // - 따라서 없어도 안 되고, 2개여도 안 됨.
    // - 사용하는 이유: 어디에서나 쉽게 접근이 가능한 구조를 제공하기 위해.
    // 이것도 원래는 맹신하던 구조였는데 지금은 안 쓰자 주의다.
    // 어디서나 접근할 수 있도록 싱글톤은 static으로 둔다.
    // 싱글톤 필드.
    private static ScoreManager instance = null;


    // 점수 데이터.
    // 아래와 같이 생성하는 것이 특정 버전 이상부터는 허용되었다.
    [SerializeField] private Score score = new Score();


    // 텍스트 UI 참조 변수.
    [SerializeField] private TMPro.TextMeshProUGUI scoreText;
    [SerializeField] private TMPro.TextMeshProUGUI bestScoreText;

    // 싱글톤 접근 프로퍼티
    // C#은 이렇게도 할 수 있다.
    //public static ScoreManager Instance { get { return instance; } }

    // 싱글톤 접근 메시지 - 공개 메소드.
    // 싱글톤 사용 시에 일반적으로는 Get이라는 메소드 이름을 사용한다.
    public static ScoreManager Get()
    {
        return instance;
    }


    // 점수 획득 함수 (메시지 - 인터페이스, 공개 메소드).
    public void AddScore(int gainScore)
    {
        score.Add(gainScore);
    }

    private void Awake()
    {
        // 검증 후 싱글톤 초기화.
        // instance가 null인 경우는 생성이 필요한 경우이기 때문에 이 게임 오브젝트를 싱글톤 객체로 설정.
        if (instance == null)
        {
            instance = this;
        }
        // instance가 null이 아니라면, 다른 객체가 이미 싱글톤으로 설정돼 있다는 의미(다른 기능이 망가지면 안 되므로)이기 때문에 이 객체는 삭제해야 함.
        else
        {
            Destroy(gameObject);
        }
        
        // 점수 초기화.
        score.SetTextUI(scoreText, bestScoreText);
        score.Initialize();
    //    if (score == null)
    //    {
    //        score = new Score();
    //    }
    }
}
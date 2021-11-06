using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranking_Ps : MonoBehaviour
{
    [SerializeField] GameObject m_rankingPrefab;
    ScoreManeger_Ps m_scoreManeger;
    public void Ranking()
    {
        m_scoreManeger = FindObjectOfType<ScoreManeger_Ps>();
        var ranking = Instantiate(m_rankingPrefab);
        ranking.GetComponent<RankingManager>().SetScoreOfCurrentPlay(m_scoreManeger.Score);
    }
}

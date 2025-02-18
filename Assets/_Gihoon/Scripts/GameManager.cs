using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Qubit
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager instance = null;

        private Canvas canvas = null;
        private int targetCnt = 0;
        private List<Target> qubits = new List<Target>();

        public static GameManager Instance
        {
            get 
            { 
                if (null == instance)
                {
                    // Scene ���� GameManager ã��
                    instance = FindAnyObjectByType<GameManager>();

                    // Scene ���� GameManager�� ���ٸ� ���ο� ������Ʈ ����
                    if(null == instance)
                    {
                        GameObject obj = new GameObject("GameManger");
                        instance = obj.AddComponent<GameManager>();

                        // Scene ��ȯ �� �������� �ʵ��� ����
                        DontDestroyOnLoad(obj);
                    }
                }

                return instance;
            }
        }

        // MonoBehavior �̱⿡ �����ڴ� ������ �ʴ´�.
        private GameManager() { }

        private void Awake()
        {
            // �ߺ� ����
            if(instance == null)
            {
                instance = this;
                // Scene ��ȯ �� �������� �ʵ��� ����
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                // Scene �̵��� ������ ������ Manager �� �����ϴ� ���
                // �ش� Scene �� Manager ��ü�� �����Ѵ�.
                Destroy(gameObject);
                return;
            }

            // Scene ���� Canvas Ž��
            canvas = FindAnyObjectByType<Canvas>();
            if(null == canvas)
            {
                Debug.LogError("Scene �� Canvas �� �������� �ʽ��ϴ�. Target ������ �Ұ����մϴ�.");
                return;
            }

        }

        void SetGame()
        {
            if (null == canvas)
            {
                return;
            }

            // ��ü ���� �� Scene �� ��ġ


            // List �� ��ü �߰�

            
        }

    }   // class end
}
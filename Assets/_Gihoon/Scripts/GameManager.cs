using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Qubit
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager instance = null;

        [SerializeField] GameObject contentObj = null;
        private GameObject prefab = null;
        private List<GameObject> qubits = new List<GameObject>();

        public bool bSet = false;

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

            // Qubit Prefab 
            prefab = Resources.Load<GameObject>("Prefabs/Qubit");
            if(null == prefab)
            {
                Debug.LogError("Qubit Prefab �� �ε��� �� �����ϴ�.");
                return;
            }

            // Check Qubit Parent Obj
            if (contentObj == null)
            {
                Debug.LogError("������ Qubit ��ü�� Content ��ü�� �������� �ʾҽ��ϴ�.");
                return;
            }
        }

        public void SetGame()
        {
            if (null == prefab || null == contentObj)
            {
                return;
            }

            // ��ü ���� �� Scene �� ��ġ
            int columns = 5;
            int rows = 4;
            float spacingX = 200f;
            float spacingY = 200f;

            for (int col = 0; col < columns; col++)
            {
                for (int row = 0; row < rows; row++)
                {
                    GameObject newObj = Instantiate(prefab, Vector3.zero, Quaternion.identity, contentObj.GetComponent<RectTransform>());
                    if (col % 2 == 1)
                    {
                        float zigzag = 100.0f;
                        newObj.GetComponent<RectTransform>().localPosition = new Vector3(col * spacingX, -row * spacingY - zigzag, 0);
                    }
                    else
                    {
                        newObj.GetComponent<RectTransform>().localPosition = new Vector3(col * spacingX, -row * spacingY, 0);
                    }
                    qubits.Add(newObj);
                }
            }

            /*GameObject qubit = Instantiate(prefab, contentObj.GetComponent<RectTransform>());
            // List �� ��ü �߰�
            qubits.Add(qubit);*/

            bSet = true;
        }

    }   // class end
}
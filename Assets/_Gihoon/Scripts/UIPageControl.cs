using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    /// <summary>
    /// 
    /// �ش� Ŭ������ �ʼ��� �ʿ����� ������,
    /// ���� View �� ���° View ���� ǥ�ø� ���ؼ� ���� ����ϸ� �����ϴ�.
    /// Unity �� UI �� Toggle �� Ȱ���Ѵ�.
    /// 
    /// </summary>

    public class UIPageControl : MonoBehaviour
    {
        [SerializeField]
        private Toggle toggleBase;

        private List<Toggle> listToggles = new List<Toggle>();

        private void Awake()
        {
            // ���� ���� ������ �ε������ʹ� ��Ȱ��ȭ���� �д�.
            toggleBase.gameObject.SetActive(false);
        }

        public void SetNumberOfPage(int number)
        {
            if(listToggles.Count < number)
            {
                // ������ �ε������� ���� ������ ������ ������ ������
                // ���� ���� ������ �ε������ͷκ��� ���ο� ������ �ε������͸� �ۼ��Ѵ�.
                for (int i = listToggles.Count; i < number; ++i)
                {
                    Toggle indicator = Instantiate(toggleBase) as Toggle;
                    indicator.gameObject.SetActive(true);
                    indicator.transform.SetParent(toggleBase.transform.parent);
                    indicator.transform.localScale = toggleBase.transform.localScale;
                    listToggles.Add(indicator);
                }
            }
            else if(listToggles.Count > number)
            {
                // ������ �ε������� ���� ������ ������ ������ ������ �����Ѵ�.
                for(int i = listToggles.Count - 1; i >= number; --i)
                {
                    Destroy(listToggles[i].gameObject);
                    listToggles.RemoveAt(i);
                }
            }
        }

        public void SetCurrentPage(int idx)
        {
            if(idx >= 0 && idx <= listToggles.Count - 1)
            {
                // ������ �������� �����ϵ� ������ �ε������͸� ON���� �����Ѵ�.
                // ��� �׷��� �����صξ��⿡ �ٸ� �ε������ʹ� �ڵ����� OFF�� �ȴ�.
                listToggles[idx].isOn = true;
            }
        }

    }   // end class
}

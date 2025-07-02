using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �����Ե�����
/// </summary>
public enum E_PropType
{
    
    Atk,
    Def,
    MaxHp,
    Hp,
}
public class PropReward : MonoBehaviour
{
    public E_PropType type = E_PropType.Atk;
    public int changeValue = 2;
    //��ȡ��Ч
    public GameObject getEff;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //�õ���Ӧ�����
            PlayerObj player = other.GetComponent<PlayerObj>();
            switch (type)
            {
                case E_PropType.Atk:
                    player.atk += changeValue;
                    break;
                case E_PropType.Def:
                    player.def += changeValue;
                    break;
                case E_PropType.MaxHp:
                    player.maxHp += changeValue;
                    //����Ѫ��
                    GamePanel.Instance.UpdateHP(player.maxHp, player.hp);
                    break;
                case E_PropType.Hp:
                    player.hp += changeValue;
                    if (player.hp > player.maxHp)
                        player.hp = player.maxHp;
                    GamePanel.Instance.UpdateHP(player.maxHp, player.hp);
                    break;
            }
            GameObject eff = Instantiate(getEff, this.transform.position, this.transform.rotation);
            //��Ч��С�Ϳ���
            AudioSource audioSource = eff.GetComponent<AudioSource>();
            audioSource.volume = GameDataMgr.Instance.musicData.soundValue;
            audioSource.mute = !GameDataMgr.Instance.musicData.isOpenSound;

            Destroy(this.gameObject);
        }
    }
}

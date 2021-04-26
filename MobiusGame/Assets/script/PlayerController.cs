using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    public float speed; // ��������
    public Text scoreText; // �X�R�A�� UI
    public Text winText; // ���U���g�� UI
    public Text Plv;//���x���\�L
    public Text Pexp;//���݂ۗ̕L�o���l

    private Rigidbody rb; // Rididbody
    private int score; // �X�R�A
    private int m_exp=3;//�K�v�o���l
    private int exp=0;//���݂ۗ̕L�o���l
  [SerializeField]  private int lv = 1;
   
    void Start()
    {
        // Rigidbody ���擾
        rb = GetComponent<Rigidbody>();

        // UI ��������
        score = 0;
        SetCountText();
        SetCountLV();
        winText.text = "";
    }

    void Update()
    {
        // �J�[�\���L�[�̓��͂��擾
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");

        // �J�[�\���L�[�̓��͂ɍ��킹�Ĉړ�������ݒ�
        var movement = new Vector3(moveHorizontal, 0, moveVertical);

        // Ridigbody �ɗ͂�^���ċʂ𓮂���
        rb.AddForce(movement * speed);
    }

    // �ʂ����̃I�u�W�F�N�g�ɂԂ��������ɌĂяo�����
    void OnTriggerEnter(Collider other)
    {
        // �Ԃ������I�u�W�F�N�g�����W�A�C�e���������ꍇ
        if (other.gameObject.CompareTag("Pick Up"))
        {
            // ���̎��W�A�C�e�����\���ɂ��܂�
            other.gameObject.SetActive(false);

            // �X�R�A�����Z���܂�
            score = score + 1;

            //exp�����Z
            exp = exp + 1;

            if (exp>=m_exp)
            {
                lv = lv + 1;
                exp = 0;
                m_exp =lv * 3;
            }

            // UI �̕\�����X�V���܂�
            SetCountText();
            SetCountLV();
        }
    }

    // UI �̕\�����X�V����
    void SetCountText()
    {
        // �X�R�A�̕\�����X�V
        scoreText.text = "Count: " + score.ToString();

        // ���ׂĂ̎��W�A�C�e�����l�������ꍇ
        if (score >= 12)
        {
            // ���U���g�̕\�����X�V
            winText.text = "You Win!";
        }
    }
    void SetCountLV()
    {
        // �X�R�A�̕\�����X�V
        Plv.text = "Lv" + lv.ToString();
        Pexp.text = "exp�F" + exp.ToString();

    }
}

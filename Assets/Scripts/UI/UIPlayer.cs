using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayer : MonoBehaviour
{
    #region References
    [Header("Dash")]
    [SerializeField]
    private Image _dashImage;
    [SerializeField]
    private float _dashCooldown = 0.5f;
    private bool _isCooldown = false;
    private bool _canDash = false;
    [SerializeField]
    GameObject _dashActivado;

    [Header("Escudo")]
    [SerializeField]
    private Image _escudoImage;
    [SerializeField]
    private GameObject _escudoAct;
    [SerializeField]
    private GameObject _escudoDesact;
    private float _escudoCooldown = 10.0f;
    private bool _isActive = false;
    private bool _escudoUI = false;
    private bool _isMoving = false;
    #endregion
    #region Methods
    public void CanDashUI()
    {
        _canDash = true;
    }
    public void EscudoUI()
    {
        _escudoUI = true;
    }
    private void DashAbility()
    {
        if (_canDash == true && _isCooldown == false)
        {
            _isCooldown = true;
            _dashImage.fillAmount = 1;
        }

        if (_isCooldown)
        {
            _dashActivado.SetActive(false);
            _dashImage.fillAmount -= 1 / _dashCooldown * Time.deltaTime;

            if (_dashImage.fillAmount <= 0)
            {
                _dashImage.fillAmount = 0;
                _isCooldown = false;
                _dashActivado.SetActive(true);
                _canDash = false;
            }
        }
    }
    void EscudoScore()
    {

        if (_isMoving == false && GameManager.Instance.Gear >= 5)
        {
            _escudoDesact.SetActive(false);
            _escudoAct.SetActive(true);
        }
        else
        {
            _escudoDesact.SetActive(true);
            _escudoAct.SetActive(false);
        }
    }
    private void EscudoAbility()
    {
        if (_escudoUI == true && _isActive == false)
        {
            _isActive = true;
            _escudoImage.fillAmount = 1;
            _isMoving = true;
        }

        if (_isActive)
        {
            _escudoDesact.SetActive(false);
            _escudoImage.fillAmount -= 1 / _escudoCooldown * Time.deltaTime;

            if (_escudoImage.fillAmount <= 0)
            {
                _escudoImage.fillAmount = 0;
                _isActive = false;
                _escudoDesact.SetActive(true);
                _escudoUI = false;
                _isMoving=false;
            }
        }
    }
    #endregion
    void Start()
    {
        _dashImage.fillAmount = 0;
        _escudoImage.fillAmount = 0;
    }
    void Update()
    {
        DashAbility();
        EscudoScore();
        EscudoAbility();
    }
}

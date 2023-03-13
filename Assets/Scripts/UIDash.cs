using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDash : MonoBehaviour
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
    #endregion
    #region Methods
    public void CanDashUI()
    {
        _canDash = true;
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
    #endregion
    void Start()
    {
        _dashImage.fillAmount = 0;
    }
    void Update()
    {
        DashAbility();
    }
}

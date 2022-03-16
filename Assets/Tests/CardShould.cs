using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CardShould
{
    /**
     *  Una carta tiene vida y daño
        una carta puede golpear otra carta y el daño de la 
        carta a golpear se toma en la vida de la otra carta
        las cartas se destruyen cuando llegan a 0 de vida
     * */

    private Card _cardOne;
    private Card _cardTwo;

    private const int DAMAGECARDONE = 3;
    private const int LIFECARDONE = 2;
    private const int DAMAGECARDTWO = 4;
    private const int LIFECARDTWO = 5;

    [SetUp]
    public void SetUp()
    {
        _cardOne = new Card(DAMAGECARDONE, LIFECARDONE);
        _cardTwo = new Card(DAMAGECARDTWO, LIFECARDTWO);
    }

    [Test]
    public void OnCreateHasLifeAndDamage()
    {
        Assert.AreEqual(DAMAGECARDONE, _cardOne.GetDamage());
        Assert.AreEqual(LIFECARDONE, _cardOne.GetLife());

    }

    [Test]
    public void HitAnotherCard()
    {
        int cardTwoLifeBeforeHit = _cardTwo.GetLife();

        _cardOne.Hit(_cardTwo);

        Assert.AreEqual(cardTwoLifeBeforeHit - DAMAGECARDONE, _cardTwo.GetLife());
    }

    [Test]
    public void ReceiveDamageWhenAttackAnotherCardWithDamage()
    {
        int cardOneLifeBeforeAttack = _cardOne.GetLife();

        _cardOne.Hit(_cardTwo);

        Assert.AreEqual(cardOneLifeBeforeAttack - DAMAGECARDTWO, _cardOne.GetLife());
    }

    [Test]
    public void BeDestroyedWhenLifeIsEqualOrLessThanZero()
    {
        int cardOneLifeBeforeAttack = _cardOne.GetLife();

        _cardOne.Hit(_cardTwo);

        Assert.IsTrue(_cardOne.IsDestroyed());
    }

}

public class Card
{
    private int _damage;
    private int _life;
    private bool _isDestroyed;

    public Card(int damage, int life)
    {
        _damage = damage;
        _life = life;
        _isDestroyed = false;
    }

    public int GetDamage()
    {
        return _damage;
    }

    public int GetLife()
    {
        return _life;
    }

    public void Hit(Card target)
    {
        target.ReceiveDamage(_damage);

        this.ReceiveDamage(target.GetDamage());
    }

    private void Destroy()
    {
        _isDestroyed = true;
    }

    public bool IsDestroyed()
    {
        return _isDestroyed;
    }

    private void ReceiveDamage(int damage)
    {
        _life -= damage;

        if (_life <= 0)
        {
            Destroy();
        }
    }
}
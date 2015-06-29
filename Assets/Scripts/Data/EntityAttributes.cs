using UnityEngine;
using System.Collections;
using System.Xml;

public class EntityAttributes : MonoBehaviour {

    [HideInInspector]
    public int strength;
    [HideInInspector]
    public int agility;
    [HideInInspector]
    public int endurance;

    /*Производные от силы (strength)*/
    public int carryWeight;
    public int hitPoint;
    public int meleeDamage;

    /*Производные от ловкости (agility)*/
    public int precision;
    public int armorClass;
    public int sequence;

    /*Производные от выносливости (endurance)*/
    public int dodge;
    public int resistance;
    public int recovery;


    void Start() {
        strength = 1;
        agility = 3;
        endurance = 3;

        carryWeight = 3 + (2 * strength);
        hitPoint = strength * 20;
        meleeDamage = strength; //В процентах

        precision = agility; //В процентах
        armorClass = agility / 2;
        sequence = agility;

        dodge = endurance * 3;
        resistance = endurance / 2;
        recovery = endurance * 10;

        Debug.Log(hitPoint);
        XmlDocument xDoc = new XmlDocument();
        xDoc.Load("./Assets/Scripts/Data/enemiesAttributes.xml");
        XmlElement xRoot = xDoc.DocumentElement;
        foreach (XmlNode xnode in xRoot) {
            if (xnode.Attributes.Count > 0)
            {
                XmlNode attr = xnode.Attributes.GetNamedItem("name");
                if (attr != null)
                    Debug.Log(attr.Value);
            }
        }
    }


    /*Состояния
        Усталось
     * Голод
     * Повреждения
     * Болезнь
     */

    /* Навыки
     Оружейник (создание и улучшение оружия)
     * Ремотник (ремонт сломанных вещей)
     * Стрелок (владение оружием дальнего боя)
     * Боец (владение оружием ближнего боя)
     * Повар (приготовление пищи)
     * Взломщик (взлом замков)
     * Бартер (барыга)
     * Счастливчик (как часто удача поворачивается к тебе лицом)
     * Доктор (приготовление лекарств, заживление ран)
     * Строитель (создание предметов быта)
     */

}

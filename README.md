# 🏰 Rogue-Like-TD
## A Rogue-Lite Tower Defense Experience

### About the Game
**Rogue-Like-TD** is a tower defense game enriched with roguelite elements. Your main objective is to protect your main tower against the waves of approaching enemies.

---

## ⚙️ Core Mechanics

### 🛡️ Main Tower Management

The main tower is your central base where you can build and manage your defense towers.

| State | Visual | Description |
| :--- | :--- | :--- |
| **Outside Tower** | <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/MainTower/main%20tower%20out.png" width="300px"> | When outside the tower, you can fight and move around the map. |
| **Entering the Tower** | <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/MainTower/main%20tower%20buttonn.png" width="300px"> | To enter the main tower, your character must be close to it, and you must click this button. |
| **Inside Tower** | <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/MainTower/main%20tower%20inside.png" width="300px"> | Once inside, you can manage all towerplacements, build, and upgrade towers. |

### 🔨 Tower Placement and Upgrading

When you click on a TowerPlacement, you are offered 4 different options for building a tower.

| Tower Placement | Tower Information Panel |
| :--- | :--- |
| <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/TOWERS/TowerPlacement.png" width="300px"> | <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/TOWERS/TowerInfoPanel.png" width="300px"> |

In the tower information panel:
* **Yellow text:** Is the price of the tower.
* **Middle text:** Is the tower's description.
* **Numbers next to the skull:** Show the tower's damage.
    * **Orange** text indicates **physical damage**.
    * **Purple** text indicates **magic damage**.

**Upgrade System:**
1.  Each tower can be upgraded up to a maximum of **Level 4**.
2.  After reaching the fourth level, the tower offers you **two different evolve options**.
3.  The evolved tower can be upgraded up to a maximum of **Level 3** after evolution.

### 🏹 Tower Types

| Tower | Level 1 | Evolve 1 | Evolve 2 |
| :--- | :--- | :--- | :--- |
| **Archer Tower** | Shoots arrows at the closest enemy. <br> <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Towers/Archer/Archer1.gif" width="200px"> | Attack speed and damage increase. <br> <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Towers/Archer/ArcherEvolved1.gif" width="200px"> | Hits slower but deals **true damage**, not physical damage. <br> <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Towers/Archer/ArcherEvolved2.gif" width="200px"> |
| **Magic Tower** | Casts a spell to the closest enemy. <br> <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Towers/Mage/Mage1.gif" width="200px"> | Attack speed and damage increase. <br> <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Towers/Mage/MageEvolved1.gif" width="200px"> | Throws lightning that **bounces** off other enemies. <br> <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Towers/Mage/MageEvolved2.gif" width="200px"> |
| **Guard Tower** | Spawns a soldier to defend the tower. If the soldier dies, it respawns after a cooldown. <br> <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Towers/Guard/Guard1.gif" width="200px"> | The soldier takes no **physical damage**. <br> <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Towers/Guard/GuardEvolved2.gif" width="200px"> | The soldier takes no **magic damage**. <br> <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Towers/Guard/GuardEvolved1.gif" width="200px"> |
| **Catapult Tower** | Throws a stone to the closest enemy. <br> <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Towers/Catapult/Catapult1.gif" width="200px"> | Attack speed and damage increase. <br> <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Towers/Catapult/CatapultEvolved1.gif" width="200px"> | Shoots a lightning ball that briefly **stuns** all enemies it hits. <br> <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Towers/Catapult/CatapultEvolved2.gif" width="200px"> |

---

### 👾 Enemy Mechanics

* Enemies arrive at fixed intervals. <br> <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/Enemy1.png" width="480PX">
* Some enemies attack at close range, others from afar.
* You can **avoid** ranged enemies' shots.
* Every enemy that dies drops a **gem** on the ground, which is used for character experience. <br> <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/Gem.png" width="240px">

### 🧑‍ Character Mechanics

Your main character helps your towers kill enemies.

* **Death and Respawn:** When the character dies, it enters a cooldown and respawns from the main tower when the time is up.
* **Tower Management:** The character can still manage towers even during cooldown. <br> <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/PlayerDead.gif" width="480px">
* **Skill System:** You have 5 active and 5 passive skills to use against enemies.

#### Leveling Up
* To acquire skills, you must **level up**.
* To level up, you must fill the experience bar at the top. <br> <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/LevelUPBar.png" width="480PX">
* To gain experience, you must collect the **gems** dropped by enemies.

---

## ✨ Skill System

### Passive Skills

| Icon | Skill Name | Description |
| :--- | :--- | :--- |
| <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/Pasife/Armor.png" width="48px"> | **Armor** | Reduces physical damage taken. |
| <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/Pasife/Cooldown.png" width="48px"> | **Clock** | Reduces the cooldown of active skills. |
| <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/Pasife/Damage.png" width="48px"> | **Gold Dagger** | Increases active skills' damage. |
| <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/Pasife/HealRegen.png" width="48px"> | **PointHeart** | Increases health regeneration every second. |
| <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/Pasife/Health.png" width="48px"> | **SecondHeart** | Increases base health. |
| <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/Pasife/Lethality.png" width="48px"> | **Lethality** | Ignores enemy's armor (Armor Penetration). |
| <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/Pasife/Life%20Steal.png" width="48px"> | **Tooths** | Steals HP from skill damage dealt (Life Steal). |
| <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/Pasife/Magic%20Penetration.png" width="48px"> | **Magic Penetration** | Ignores enemy's magic resistance. |
| <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/Pasife/Magic%20Resistance.png" width="48px"> | **Purple Shield** | Reduces magic damage taken. |
| <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/Pasife/MoveSpeed.png" width="48px"> | **Magic Boots** | Increases movement speed. |

### Active Skills

| Icon | Skill Name | Description | Visual |
| :--- | :--- | :--- | :--- |
| <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/Active%20Icon/BOF.png" width="48px"> | **Beam Of Light** | Shoots a beam of light. | <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Skills/Normal/BOF.gif" width="300px"> |
| <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/Active%20Icon/BloodRain.png" width="48px"> | **Raining Blood** | Spawns a rain of blood. | <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Skills/Normal/Bloodrain.gif" width="300px"> |
| <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/Active%20Icon/BrightShield.png" width="48px"> | **BrightShield** | Reflects incoming damage back to the sender. | <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Skills/Normal/BrightShield.gif" width="300px"> |
| <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/Active%20Icon/Dagger.png" width="48px"> | **Dagger** | Throws a dagger. | <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Skills/Normal/Dagger.gif" width="300px"> |
| <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/Active%20Icon/DarkBlade.png" width="48px"> | **Dark Blade** | Spins a blade around. | <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Skills/Normal/DarkBlade.gif" width="300px"> |
| <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/Active%20Icon/DarkAura.png" width="48px"> | **DarkAura** | Deals damage to an area (Area Damage). | <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Skills/Normal/DarkAura.gif" width="300px"> |
| <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/Active%20Icon/Fireball.png" width="48px"> | **Fireball** | Randomly shoots a fireball. | <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Skills/Normal/Fireball.gif" width="300px"> |
| <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/Active%20Icon/Spikes.png" width="48px"> | **Spike** | Pulls spikes out of the ground. | <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Skills/Normal/Spike.gif" width="300px"> |
| <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/Active%20Icon/tornado.png" width="48px"> | **Tornado** | Sends a tornado. | <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Skills/Normal/Tornado.gif" width="300px"> |
| <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/Active%20Icon/Vine.png" width="48px"> | **Vine** | Spins vines around. | <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Skills/Normal/Vine.gif" width="300px"> |

### 💫 Skill Evolution Mechanic

You can evolve every active skill. To do this:

1.  You must possess the **Passive Skill** required by the Active Skill you wish to evolve.
2.  You must level both skills up to **Level 5**.
3.  You must unlock the **Treasure** dropped by a boss.

| Treasure | Evolution Panel |
| :--- | :--- |
| <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/Treasure.png" width="300px"> | <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/EvolvePanel.png" width="300px"> |

#### Evolved Active Skills

| Icon | Skill Name | Description | Visual |
| :--- | :--- | :--- | :--- |
| <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/Active%20Icon/BOF%2B%2B.png" width="48px"> | **Beam Of Light Evolved** | The light beam is **always on**. | <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Skills/Evolved/Bof.gif" width="300px"> |
| <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/Active%20Icon/BloodRain%2B%2B.png" width="48px"> | **Raining Blood Evolved** | Towers it touches gain **extra attack speed**. | <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Skills/Evolved/BloodRain.gif" width="300px"> |
| <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/Active%20Icon/BrightShield%2B%2B.png" width="48px"> | **BrightShield Evolved** | Gains **HP from every enemy** it hits (Life Steal effect). | <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Skills/Evolved/BrightShield.gif" width="300px"> |
| <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/Active%20Icon/Dagger%2B%2B%20v2.png" width="48px"> | **Dagger Evolved (Axe)** | Daggers turn into **axes**. | <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Skills/Evolved/Dagger.gif" width="300px"> |
| <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/Active%20Icon/DarkBlade%2B%2B.png" width="48px"> | **Dark Blade Evolved** | Gains **HP from every enemy** it hits (Life Steal effect). | <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Skills/Evolved/DarkBlade.gif" width="300px"> |
| <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/Active%20Icon/DarkAura%2B%2B.png" width="48px"> | **DarkAura Evolved** | Towers it touches gain **extra damage**. | <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Skills/Evolved/DarkAura.gif" width="300px"> |
| <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/Active%20Icon/Fireball%2B%2B.png" width="48px"> | **Fireball Evolved** | The **attack area increases**. | <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Skills/Evolved/FireBall.gif" width="300px"> |
| <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/Active%20Icon/Spikes%2B%2B.png" width="48px"> | **Spike Evolved** | **Slows** enemies it touches. | <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Skills/Evolved/Spike.gif" width="300px"> |
| <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/Active%20Icon/Tornado%2B%2B.png" width="48px"> | **Tornado Evolved** | **Poisons** enemies and deals damage over time (DoT). | <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Skills/Evolved/Tornado.gif" width="300px"> |
| <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/Active%20Icon/Vine%2B%2B.png" width="48px"> | **Vine Evolved** | The **vine size increases**. | <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Skills/Evolved/Vine.gif" width="300px"> |

### When All Skills are Maxed

When your skill levels are maxed, you can choose one of the following three options when leveling up:

| Option | Description |
| :--- | :--- |
| **Gold** | Gain 200 Gold. |
| **HP** | Gain 35 Health (HP). |
| **PD** | Gain 25 Permanent Development Points (PD). |

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SkillFulled.png" width="300px">

---

## ♾️ Rogue-lite Permanent Development (PD System)

### PD Acquisition
* Every enemy killed has a low chance of dropping PD (Permanent Development Points).
* You can also gain PD from the level-up screen when all your skills are maxed.

You can use the PD you earn in the **PD Level Up Panel** in the main menu to unlock permanent features:

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/Power-up.png" width="300px">

| Icon | Feature Name | Description | Scope |
| :--- | :--- | :--- | :--- |
| <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/PD/Koleks.png" width="48px"> | **Koleks** | Extra cooldown reduction for active skills. | Character |
| <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/PD/RedDagger.png" width="48px"> | **RedDagger** | Extra damage for active skills. | Character |
| <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/PD/WiseBook.png" width="48px"> | **WiseBook** | Gain extra experience from XP gems. | Character |
| <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/PD/Midas.png" width="48px"> | **Midas** | Gain extra Gold from enemies. | Character |
| <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/PD/RedHeart.png" width="48px"> | **RedHeart** | Extra HP for your main character. | Character |
| <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/PD/Pluses.png" width="48px"> | **Pluses** | Extra HP regen for your main character. | Character |
| <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/PD/Nixe.png" width="48px"> | **Nixe** | Extra movespeed for your main character. | Character |
| <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/PD/FastHand.png" width="48px"> | **FastHand** | Throwable abilities have more throwables. | Character |
| <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/PD/BlueKnife.png" width="48px"> | **BlueKnife** | Increases tower attack speed. | Towers |
| <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/PD/ShinyBlade.png" width="48px"> | **ShinyBlade** | Increases tower damage. | Towers |
| <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/PD/FakeHeart.png" width="48px"> | **FakeHeart** | Extra HP for all towers. | Towers |
| <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/PD/Kervace.png" width="48px"> | **Kervace** | Reduces the main character's respawn time. | Character |

---

## 📺 Gameplay GIFs

| Gameplay GIF 1 | Gameplay GIF 2 | Gameplay GIF 3 |
| :--- | :--- | :--- |
| <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Gameplay1.gif" width="300px"> | <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Gameplay2.gif" width="300px"> | <img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Gameplay3.gif" width="300px"> |

## 🎬 Videos
* **[Tutorial](https://www.youtube.com/watch?v=DgDxK5A_f4g)**
* **[Gameplay](https://www.youtube.com/watch?v=1yOtL2DiSMU)**

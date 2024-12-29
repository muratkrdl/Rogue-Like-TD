# Rogu-Like-TD


## Used design patterns in this project

#### Singleton

#### Object Pooling

#### FlyWeight

#### State Machine

#### Observer


# About game

## This is a rogu-lite tower defense game

## The main goal of the game is to protect the main tower.

# Mechanics

## Main tower mechanics

### To build and manage towers, your character must be inside the tower

## Outside Tower

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/MainTower/main%20tower%20out.png" width="auto">

### To enter the main tower, your character must be close to the main tower and you must click this button

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/MainTower/main%20tower%20buttonn.png" width="auto">

### After entering the main tower, you can manage all towerplacements

## Inside Tower

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/MainTower/main%20tower%20inside.png" width="auto">


## Placetower mechanics

### Each tower can be upgraded up to 4 levels.

### After reaching the fourth level the tower offers you two options

### After choosing one of these two options and evolving the tower, the evolved tower can be upgraded to a maximum of level three.

## TowerPlacement

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/TOWERS/TowerPlacement.png" width="auto">

### After clicking on the towerplacement, you must choose one of these 4 options

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/TOWERS/TowerInfoPanel.png" width="auto">

### When you place the cursor on one of the buttons, an information panel will open as you can see in the picture

### The yellow text is the price of the tower

### The text in the middle is a description of the tower

### The numbers next to the skull show the damage to the tower

#### If this text is orange, the tower has physical damage, if it is purple, it has magic damage


## Archer tower

### Shoots arrows at the closest enemy

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Towers/Archer/Archer1.gif" width="auto">

### Archer tower evolve 1

#### Attack speed and damage increases

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Towers/Archer/ArcherEvolved1.gif" width="auto">

### Archer tower evolve 2

#### Hits slower but deals true damage, not physical damage

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Towers/Archer/ArcherEvolved2.gif" width="auto">


## Magic tower

### Casts a spell to the closest enemy

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Towers/Mage/Mage1.gif" width="auto">

### Magic tower evolve 1

#### Attack speed and damage increases

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Towers/Mage/MageEvolved1.gif" width="auto">

### Magic tower evolve 2

#### It throws lightning and the lightning it throws bounces off other enemies

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Towers/Mage/MageEvolved2.gif" width="auto">


## Guard tower

### spawns a soldier to defend the tower

### If the soldier dies, it spawns another soldier after a certain period of time.

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Towers/Guard/Guard1.gif" width="auto">

### Guard tower evolve 1

#### The soldier does not take physical damage

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Towers/Guard/GuardEvolved2.gif" width="auto">

### Guard tower evolve 2

#### The soldier does not take magic damage

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Towers/Guard/GuardEvolved1.gif" width="auto">


## Catapult tower

### throws a stone to the closest enemy

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Towers/Catapult/Catapult1.gif" width="auto">

### Catapult evolve 1

#### Attack speed and damage increases

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Towers/Catapult/CatapultEvolved1.gif" width="auto">

### Catapult evolve 2

#### Shoots a ball of lightning that briefly stuns all enemies it hits

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Towers/Catapult/CatapultEvolved2.gif" width="auto">


## Enemy mechanics

### Enemies come at certain periods

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/Enemy1.png" width="auto">

### Some enemies attack from close range, some from far away

### You can avoid ranged enemies' shots

### Every enemy that dies drops a gem on the ground (The function of the gems will be explained in the player section)


## Player mechanics

### Your character helps your towers to kill enemies

### When the character dies, it goes into a cooldown and when the time is up, she respawns from the main tower

### The main character can manage towers during cooldown

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/PlayerDead.gif" width="auto">

### You have 5 active and 5 passive skills to hit the enemies

### To get these skills, you need to level up and fill the experience bar at the top to level up

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/LevelUPBar.png" width="auto">

### To gain experience, you must collect the gems dropped by enemies

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/Gem.png" width="auto">



# Skills mechanic


# PASIFE SKILLS


## Armor 
#### Reduces physical damage taken
<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/Pasife/Armor.png" width="48px">




## Clock
#### Cooldown reduced active skills
<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/Pasife/Cooldown.png" width="48px">




## Gold Dagger
#### Increases active skills damage 
<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/Pasife/Damage.png" width="48px">




## PointHeart
#### Increases health every second
<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/Pasife/HealRegen.png" width="48px">




## SecondHeart
#### Base health up
<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/Pasife/Health.png" width="48px">




## Lethality
#### Ignores enemy's armor
<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/Pasife/Lethality.png" width="48px">




## Tooths
#### Steals hp damage of skill dealt
<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/Pasife/Life%20Steal.png" width="48px">




## Magic Penetration
#### Ignores enemy's magic resistance
<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/Pasife/Magic%20Penetration.png" width="48px">




## Purple Shield
#### Reduces magic damage taken
<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/Pasife/Magic%20Resistance.png" width="48px">




## Magic Boots
#### Increases movement speed
<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/Pasife/MoveSpeed.png" width="48px">




# ACTIVE SKILLS

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/Active%20Icon/BOF.png" width="48px">  Beam Of Light
#### Shoots a beam of light

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Skills/Normal/BOF.gif" width="640px">




<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/Active%20Icon/BloodRain.png" width="48px"> Raining Blood
#### Spawn a rain

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Skills/Normal/Bloodrain.gif" width="640px">




<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/Active%20Icon/BrightShield.png" width="48px"> BrightShield
#### Reflects incoming damage to the sender

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Skills/Normal/BrightShield.gif" width="640px">




<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/Active%20Icon/Dagger.png" width="48px"> Dagger
#### Throws a dagger

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Skills/Normal/Dagger.gif" width="640px">




<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/Active%20Icon/DarkBlade.png" width="48px"> Dark Blade
#### Spins a blade around

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Skills/Normal/DarkBlade.gif" width="640px">




<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/Active%20Icon/DarkAura.png" width="48px"> DarkAura
#### Damage to area

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Skills/Normal/DarkAura.gif" width="640px">




<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/Active%20Icon/Fireball.png" width="48px"> Fireball
#### Random shoots fireball

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Skills/Normal/Fireball.gif" width="640px">




<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/Active%20Icon/Spikes.png" width="48px"> Spike
#### Pulls spikes out of the ground

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Skills/Normal/Spike.gif" width="640px">




<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/Active%20Icon/tornado.png" width="48px"> Tornado
#### Sends a tornado

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Skills/Normal/Tornado.gif" width="640px">




<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/Active%20Icon/Vine.png" width="48px"> Vine
#### Spins vines around

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Skills/Normal/Vine.gif" width="640px">




## Evolve skill mechanic

### You can evolve every active skill

### To evolve an active skill, you must have the passive skill that the active skill requires

#### But having this skill is not enough, then you must reach both of these skills to level five

#### After you have leveled both skills to level five, you must unlock the treasure dropped by a boss

## Treasure

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/Treasure.png" width="auto">

## Evolution list

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/EvolvePanel.png" width="auto">


<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/Active%20Icon/BOF%2B%2B.png" width="48px"> Beam Of Light Evolved
#### The light beam is always on

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Skills/Evolved/Bof.gif" width="640px">




<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/Active%20Icon/BloodRain%2B%2B.png" width="48px"> Raining Blood Evolved 
#### Towers it touches gain extra attack speed

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Skills/Evolved/BloodRain.gif" width="640px">




<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/Active%20Icon/BrightShield%2B%2B.png" width="48px"> BrightShield Evolved
#### Gains HP from every enemy it hits

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Skills/Evolved/BrightShield.gif" width="640px">




<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/Active%20Icon/Dagger%2B%2B%20v2.png" width="48px"> Dagger Evolved (Axe)
#### Daggers turn into axes

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Skills/Evolved/Dagger.gif" width="640px">




<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/Active%20Icon/DarkBlade%2B%2B.png" width="48px"> Dark Blade Evolved 
#### Gains HP from every enemy it hits

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Skills/Evolved/DarkBlade.gif" width="640px">




<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/Active%20Icon/DarkAura%2B%2B.png" width="48px"> DarkAura Evolved 
#### Towers it touches gain extra damage

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Skills/Evolved/DarkAura.gif" width="640px">




<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/Active%20Icon/Fireball%2B%2B.png" width="48px"> Fireball Evolved
#### Attack area increases

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Skills/Evolved/FireBall.gif" width="640px">




<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/Active%20Icon/Spikes%2B%2B.png" width="48px"> Spike Evolved 
#### Slows enemy it touchs

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Skills/Evolved/Spike.gif" width="640px">




<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/Active%20Icon/Tornado%2B%2B.png" width="48px"> Tornado Evolved
#### Poisons enemies and deals damage over time

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Skills/Evolved/Tornado.gif" width="640px">




<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/Active%20Icon/Vine%2B%2B.png" width="48px"> Vine Evolved
#### Vine size increases

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Skills/Evolved/Vine.gif" width="640px">




### If your skills are level five

### When you level up you choose one of the following three options

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SkillFulled.png" width="auto">

### Gold

#### Gain 200 gold


### HP

#### Gain 35 hp


### PD

### Gain 25 PD


## Rogue-lite mechanics

### Every enemy that dies has a low chance of giving you PD

### You can earn permanent features with the PD you earn from the level-up screen in the main menu


## PD Level up panel in the main menu

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/Power-up.png" width="auto">

## Koleks
#### Extra cooldown for active skills
<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/PD/Koleks.png" width="48px">




## RedDagger
#### Extra Damage for active skills
<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/PD/RedDagger.png" width="48px">




## WiseBook
#### Gain extra experience from xp gem
<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/PD/WiseBook.png" width="48px">




## Midas
#### Gain extra Gold from enemies
<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/PD/Midas.png" width="48px">




## RedHeart
#### Extra HP for your main char
<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/PD/RedHeart.png" width="48px">


## Pluses
#### Extra HP regen for your main char
<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/PD/Pluses.png" width="48px">




## Nixe
#### Extra movespeed for your main char
<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/PD/Nixe.png" width="48px">




## FastHand
#### Throwable abilities have more throwable
<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/PD/FastHand.png" width="48px">




## BlueKnife
#### Increases tower attack speed
<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/PD/BlueKnife.png" width="48px">




## ShinyBlade
#### Increases tower damage
<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/PD/ShinyBlade.png" width="48px">




## FakeHeart
#### Extra HP for all tower
<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/PD/FakeHeart.png" width="48px">




## Kervace
#### Reduces main character's respawn time
<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/PD/Kervace.png" width="48px"> 




# Some gameplay gifs

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Gameplay1.gif" width="auto">

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Gameplay2.gif" width="auto">

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/GIFS/Gameplay3.gif" width="auto">



# Tutorial 

## https://www.youtube.com/watch?v=DgDxK5A_f4g


# Gameplay 

## https://www.youtube.com/watch?v=1yOtL2DiSMU

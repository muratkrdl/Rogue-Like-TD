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

### To enter the main tower, your character must be close to the main tower and you must click this button

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/MainTower/main%20tower%20buttonn.png" width="auto">

### After entering the main tower, you can manage all towerplacements

## Outside Tower

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/MainTower/main%20tower%20out.png" width="auto">

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

<img src="--" width="auto">

### Archer tower evolve 1

#### Attack speed and damage increases

<img src="--" width="auto">

### Archer tower evolve 2

#### Hits slower but deals true damage, not physical damage

<img src="--" width="auto">


## Magic tower

### Casts a spell to the closest enemy

<img src="--" width="auto">

### Magic tower evolve 1

#### Attack speed and damage increases

<img src="--" width="auto">

### Magic tower evolve 2

#### It throws lightning and the lightning it throws bounces off other enemies

<img src="--" width="auto">


## Guard tower

### spawns a soldier to defend the tower

### If the soldier dies, it spawns another soldier after a certain period of time.

<img src="--" width="auto">

### Guard tower evolve 1

#### The soldier does not take physical damage

<img src="--" width="auto">

### Guard tower evolve 2

#### The soldier does not take magic damage

<img src="--" width="auto">


## Catapult tower

### throws a stone to the closest enemy

<img src="--" width="auto">

### Catapult evolve 1

#### Attack speed and damage increases

<img src="--" width="auto">

### Catapult evolve 2

#### Shoots a ball of lightning that briefly stuns all enemies it hits

<img src="--" width="auto">


## Enemy mechanics

### Enemies come at certain periods

### Some enemies attack from close range, some from far away

### You can avoid ranged enemies' shots

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/Enemy1.png" width="auto">

### Every enemy that dies drops a gem on the ground (The function of the gems will be explained in the player section)


## Player mechanics

### Your character helps your towers to kill enemies

### You have 5 active and 5 passive skills to hit the enemies

### To get these skills, you need to level up and fill the experience bar at the top to level up

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/LevelUPBar.png" width="auto">

### To gain experience, you must collect the gems dropped by enemies

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/Gem.png" width="auto">

### When the character dies, it goes into a cooldown and when the time is up, she respawns from the main tower

### The main character can manage towers during cooldown

<img src="--" width="auto">


## Skills mechanic


### PASIFE SKILLS

#### Armor 

#### Reduces physical damage taken

<img src="--" width="auto">


#### Clock

#### Cooldown reduced active skills

<img src="--" width="auto">


#### Gold Dagger

#### Increases active skills damage 


#### PointHeart

#### Increases health every second

<img src="--" width="auto">


#### SecondHeart

#### Base health up

<img src="--" width="auto">


#### Lethality

#### Ignores enemy's armor

<img src="--" width="auto">


#### Tooths

#### Steals hp damage of skill dealt

<img src="--" width="auto">


#### Magic Penetration

#### Ignores enemy's magic resistance

<img src="--" width="auto">


#### Purple Shield

#### Reduces magic damage taken

<img src="--" width="auto">


#### Magic Boots

#### Increases movement speed

<img src="--" width="auto">


#### ACTIVE SKILLS

#### Beam Of Light

#### Shoots a beam of light

<img src="--" width="auto">

<img src="--" width="auto">


#### Raining Blood

#### Spawn a rain

<img src="--" width="auto">

<img src="--" width="auto">


#### BrightShield

#### Reflects incoming damage to the sender

<img src="--" width="auto">

<img src="--" width="auto">


#### Dagger

#### Throws a dagger

<img src="--" width="auto">

<img src="--" width="auto">


#### Dark Blade

#### Spins a blade around

<img src="--" width="auto">

<img src="--" width="auto">


#### DarkAura

#### Damage to area

<img src="--" width="auto">

<img src="--" width="auto">


#### Fireball

#### Random shoots fireball

<img src="--" width="auto">

<img src="--" width="auto">


#### Spike

#### Pulls spikes out of the ground

<img src="--" width="auto">

<img src="--" width="auto">


#### Tornado

#### Sends a tornado

<img src="--" width="auto">

<img src="--" width="auto">


#### Vine

#### Spins vines around

<img src="--" width="auto">

<img src="--" width="auto">


## Evolve skill mechanic

### You can evolve every active skill

### To evolve an active skill, you must have the passive skill that the active skill requires

#### But having this skill is not enough, then you must reach both of these skills to level five

#### After you have leveled both skills to level five, you must unlock the treasure dropped by a boss

## Treasure

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/Treasure.png" width="auto">

## Evolution list

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/EvolvePanel.png" width="auto">


#### Beam Of Light Evolved

#### The light beam is always on

<img src="--" width="auto">

<img src="--" width="auto">


#### Raining Blood Evolved 

#### Towers it touches gain extra attack speed

<img src="--" width="auto">

<img src="--" width="auto">


#### BrightShield Evolved

#### Gains HP from every enemy it hits

<img src="--" width="auto">

<img src="--" width="auto">


#### Dagger Evolved (Axe)

#### Daggers turn into axes

<img src="--" width="auto">

<img src="--" width="auto">


#### Dark Blade Evolved 

#### Gains HP from every enemy it hits

<img src="--" width="auto">

<img src="--" width="auto">


#### DarkAura Evolved 

#### Towers it touches gain extra damage

<img src="--" width="auto">

<img src="--" width="auto">


#### Fireball Evolved

#### Attack area increases

<img src="--" width="auto">

<img src="--" width="auto">


#### Spike Evolved 

#### Slows enemy it touchs

<img src="--" width="auto">

<img src="--" width="auto">


#### Tornado Evolved

#### Poisons enemies and deals damage over time

<img src="--" width="auto">

<img src="--" width="auto">


#### Vine Evolved

#### Vine size increases

<img src="--" width="auto">

<img src="--" width="auto">


### If your skills are level five

### When you level up you choose one of the following three options

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SkillFulled.png" width="auto">

#### Gold

#### Gain 200 gold


#### HP

#### Gain 35 hp


#### PD

### Gain 25 PD


## Rogue-lite mechanics

### Every enemy that dies has a low chance of giving you PD

### You can earn permanent features with the PD you earn from the level-up screen in the main menu


## PD Level up panel in the main menu

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/Power-up.png" width="auto">

### Koleks

#### Extra cooldown for active skills

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/PD/Koleks.png" width="auto">


### RedDagger

#### Extra Damage for active skills

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/PD/RedDagger.png" width="auto">


### WiseBook

#### Gain extra experience from xp gem

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/PD/WiseBook.png" width="auto">


### Midas

#### Gain extra Gold from enemies

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/PD/Midas.png" width="auto">


### RedHeart

#### Extra HP for your main char

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/PD/RedHeart.png" width="auto">


### Pluses

#### Extra HP regen for your main char

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/PD/Pluses.png" width="auto">


### Nixe

#### Extra movespeed for your main char

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/PD/Nixe.png" width="auto">


### FastHand

#### Throwable abilities have more throwable

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/PD/FastHand.png" width="auto">


### BlueKnife

#### Increases tower attack speed

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/PD/BlueKnife.png" width="auto">


### ShinyBlade

#### Increases tower damage

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/PD/ShinyBlade.png" width="auto">


### FakeHeart

#### Extra HP for all tower

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/PD/FakeHeart.png" width="auto">


### Kervace

#### Reduces main character's respawn time

<img src="https://github.com/muratkrdl/Rogu-Like-TD/blob/main/Pictures%20and%20gifs/SKILLS/PD/Kervace.png" width="auto">


# Some gameplay gifs

<img src="--" width="auto">

<img src="--" width="auto">

<img src="--" width="auto">



# Tutorial 

## https://www.youtube.com/watch?v=DgDxK5A_f4g


# Gameplay 

## https://www.youtube.com/watch?v=1yOtL2DiSMU

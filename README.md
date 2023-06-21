# Mansion
## Overview
2D Игра с видом сверху (top down). Игрок заперт в старинном особняке, его цель - выжить и добраться до выхода. Чтобы выиграть, игрок должен исследовать особняк и решать головоломки. Игроку необходимо взаимодействовать с окружением и обследовать экспонаты для того, чтобы находить подсказки к головоломкам. На игрока охотится чудовище, которое с определенной периодичностью патрулирует комнаты, исследует их на факт присутствия игрока. С помощью обнаруживаемых предметов (записок) игроку необходимо находить укрытия от чудовища. 

Жанр: escape room, puzzle, horror

## Techonlogy
Игра разрабатывается на движке Unity и ЯП С#. Поведение NPC определяется деревом решений (Behavior Tree pattern). На данный момент существует всего одна ветка: задача "патрулировать особняк раз в n-ое кол-во времени". 
Контроллер игрока написан с помощью паттерна Hierarchical Finite State Machine.
Также реализуется паттерн Singleton для централизованного хранения референсов на элементы UI (UI_manager).

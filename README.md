# Matchmaking-Network-Client

~~Matchmaking Client~~ Among Us 3D with Multiplayer

## Events English
| Enum | ID | Description |
| ------ | ------ | -------- |
| START_COUNTDOWN | 1 | Start the countdown |
| STOP_COUNTDOWN | 2 | Stop the countdown |
| LOAD_GAME_SCENE | 3 | Call from host to all players when countdown in host is 0  |
| START_COUNTDOWN | 1 | Start the countdown |
| START_COUNTDOWN | 1 | Start the countdown |

## Events Russian
Все эвенты с окончанием _HOST вызываются только с хоста
| Enum | ID | Description |
| ------ | ------ | -------- |
| START_COUNTDOWN_HOST | 1 | Запуск отсчета времени |
| STOP_COUNTDOWN_HOST | 2 | Остановка отсчета времени |
| LOAD_GAME_SCENE_HOST | 3 | Запуск основной игры |
| ROLE_REVEAL_HOST | 4 | Каждному игроку назначается роль, 1 аргумент - true - экипаж, false - предатель |
| VOTING_HOST | 5 | Отправляет всем игрокам Вызывается когда игрок отправляет эвент VOTING, 1 аргумент (тип голосования) true - "Emergency Meeting", false - "Report body" |
| VOTING | 6 | 1 аргумент (тип голосования) true - "Emergency Meeting", false - "Report body" |
| POSITION | 7 | 1 аргумент (позиция) Vector3, 2 аргумент (поворот) Quaternion |
| TASK\_COMPLITED | 8 | 1 аргумент (тип задания) TASK_ENUM |
| KILL | 9 | 1 аргумент (ИД игрока убитого) int |
| VOTING_END_HOST | 10 | Окончание голосования, 1 аргумент (Решение) int (0 - пропустить, 1 - не определено, 2 - выкинуть игркока), 2 аргумент (ИД Игрока если 1 аргумент равняется 2) int |
| VICTORY | 11 | 1 аргумент (выиграли экипаж (false) или предатели (true)) boolean |

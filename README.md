# MiniArchero

Игра на данный момент представляем из себя одну сцену, но легко преобразуется под использование N сцен-уровней.

Класс Game - синглтон, который хранит в себе и управляет инстансами игровых объектов и обеспечивает их повторное использование при необходимости.

Класс ControlManager - синглон, собирающий информацию из Input и обеспечивающий управление. На данный момент реализовано управление через WSAD и стрелочки.

Класс InterfaceManager - синглон, обеспечивающий работу с UI. 

CameraController - компонент камеры, отслеживающий положение игрока и плавно ведущий камеру к нему.

PlayerSpawnPoint - класс, определяющий точку спавна игрока на уровне.

EnemySpawnPoint - класс, определяющий точку спавна противника на уровне. Содержит в себе указание на конкретный ассет противника, который будет использоваться. Кроме того, дочерние элементы этого объекта используются как точки маршрута противника.

Hero - класс описывающий героя, его состояние и действия.

Enemy - класс описывающий противника, его состояние и поведение.

Bullet - класс описывающий снаряд и его поведение.

Coin - класс описывающий монетку и ее поведение.

Constants - хранилище констант.

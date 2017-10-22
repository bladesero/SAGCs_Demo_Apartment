之前的工程因为导来导去所以弄得太乱了，这次整理了一遍
删除了上一个版本（第一人称视角）的大部分资源
留下的资源（存在Demo->PastVersion文件夹）可以使用在当前版本中
以后的资源会逐渐转移到Demo->NowVersion中

请在MainTest.scene里测试各种素材，程序

代码要求C#语言，重要函数写注释
美术要求2d精灵要匹配16:9，1920x1080分辨率，.png格式
3d模型y轴为上，从3d软件导出FBX格式，无缩放
音效要求192kbps以上，MP3格式
剧本要求xml文件，书写格式仿照Demo->Resources的GameScript

素材对应的文件夹：
音效-Audios
模型，材质，贴图及动作文件-Models(贴图在Models文件夹里另建，名字与模型对应)
UnityAnimation-Animation
2d精灵(即ui，立绘等)-Sprites
剧本，文本文件-Resources
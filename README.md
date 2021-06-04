# BlowingInstrumentController

使用说明
=======
1. 下载apk安装包到手机，并进行安装
2. 将硬件连接3.3V电源（microUSB+充电宝即可），打开手机Wi-Fi，接入ESP32热点（初始密码12345678）
3. 打开APP，即可开始演奏

功能介绍
========
1. 键盘区共有36个按键，每个按键上标注了当前调式下的音高唱名，按住按键并向吹嘴吹气或吸气即可发声，遵循笙的演奏方式
2. 界面上方功能区，单击下拉框可选择调式，切换调式后每一个按键对应音高会改变
3. 功能区标有喇叭图标的滑块可控制软件内部音量大小，单击图标可切换音量/静音

工程文件一览
------------
+ test1.apk APP安装文件
+ this_for_ESP32.ino 硬件的烧录文件，使用Arduino IDE进行烧录，需要添加Adafruit BMP280和WiFi库，并在首选项-设置中修改附加开发板管理器网址为https://dl.espressif.com/dl/package_esp32_index.json ，重启IDE，从开发板管理器中安装ESP32，选择对应开发板，即可烧录
+ midterm_presentation.pde为processing文件，是中期成果展示，可实现气压传感器对正弦波的振幅控制，processing需要安装Minim库
+ unity_project为Unity工程文件，使用Unity19.4.10版本
+ python文件夹中包含了气压振幅映射及音源处理的python文件，使用jupyter notebook打开。其中mapping为气压振幅映射代码，split_source为音源分割代码，remove_emnvelope为音源去包络代码。需要安装pyaudio、librosa、scipy、tensorflow、numpy及matplotlib等库，具体见每个文件第一行包引入部分。
+ 音源文件

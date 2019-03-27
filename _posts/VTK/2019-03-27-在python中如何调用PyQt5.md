---
layout: post
comments: true
categories: QT
---

* content
{:toc}
#### 1.准备环境，工具，软件

**环境：**win10,x64

**VERSION:**

​	python:3.6.3

**软件：**

​	pycharm：2018.3.24 x64

​	QT_creator：5.5.1

#### 2.搭建过程

1.首先打开pycharm，File->Setting。

![1553675019378](https://raw.githubusercontent.com/MaoChengEr/maochenger.github.io/master/imgs/1553675019378.png)

​	2.找到External Tools选项，按图示点击加号弹出3界面。

![1553675128517](https://raw.githubusercontent.com/MaoChengEr/maochenger.github.io/master/imgs/1553675128517.png)

3.配置Qt Designer：（启动qt的图形界面）

~~~
Name:Qt Designer
Program:D:\Qt\Qt5.5.1\5.5\msvc2013_64\bin\designer.exe(本机电脑的路径，根据自己的路径去选择)
Working Directory：$ProjectFileDir$
~~~

​	填写完点击OK按钮，保存。

3.![1553675237307](https://raw.githubusercontent.com/MaoChengEr/maochenger.github.io/master/imgs/1553675237307.png)



4.配置pyUIC：（把图形界面xxx.ui转换成xxx.py文件）

~~~
Name:pyUIC
Program:D:\program\python.exe(填写python.exe的路径)
Arguement：-m PyQt5.uic.pyuic $FileName$ -o $FileNameWithoutExtension$.py
Working Directory：$FileDir$
~~~

​	配置完成后，点击OK按钮，保存。

![1553675583744](https://raw.githubusercontent.com/MaoChengEr/maochenger.github.io/master/imgs/1553675583744.png)





5.配置Pyrcc:

~~~
NAME:Pyrcc
Program:D:\program\python.exe
Arguement:$FileName$ -o $FileNameWithoutExtension$_rc.py
Working Directory：$FileDir$
~~~

配置完成后，点击OK按钮，保存。

![1553675732322](https://raw.githubusercontent.com/MaoChengEr/maochenger.github.io/master/imgs/1553675732322.png)



#### 3.在python下如何调用External Tools

1.新建pyqt5工程，工程下新建文件夹pyqt5，这里仅仅起演示作用。

2.右击选择你刚刚建好的文件夹pyqt5，点击External Tools选项，会出现刚刚建立好的三个工具。

![1553675976732](https://raw.githubusercontent.com/MaoChengEr/maochenger.github.io/master/imgs/1553675976732.png)

3.点击Qt Designer，会跳出Qt的图形设计界面，这里选择Main Window，点击创建Qt界面。

![1553676158582](https://raw.githubusercontent.com/MaoChengEr/maochenger.github.io/master/imgs/1553676158582.png)

4.这里在建立三个Push Button，以演示作用，点击Crlt + S保存界面到刚刚创建的pyqt5的同级目录下。

![1553676294047](https://raw.githubusercontent.com/MaoChengEr/maochenger.github.io/master/imgs/1553676294047.png)

5.此时在pyqt5的项目中就会出现刚刚做好的UI界面，右击pyqt5.ui选择External Tools，点击pyUIC，将生成pyqt5.py文件。

![1553676692036](https://raw.githubusercontent.com/MaoChengEr/maochenger.github.io/master/imgs/1553676692036.png)

6.在pyqt5.中会生成这么一段代码，但是这段代码是不能运行的，需要在添加一些代码。（注释部分需要自己手动添加）

```python
# from PyQt5.QtWidgets import QApplication, QMainWindow
# import sys
from PyQt5 import QtCore, QtGui, QtWidgets

class Ui_MainWindow(object):
    def setupUi(self, MainWindow):
        MainWindow.setObjectName("MainWindow")
        MainWindow.resize(384, 381)
        self.centralwidget = QtWidgets.QWidget(MainWindow)
        self.centralwidget.setObjectName("centralwidget")
        self.pushButton = QtWidgets.QPushButton(self.centralwidget)
        self.pushButton.setGeometry(QtCore.QRect(150, 70, 75, 23))
        self.pushButton.setObjectName("pushButton")
        self.pushButton_2 = QtWidgets.QPushButton(self.centralwidget)
        self.pushButton_2.setGeometry(QtCore.QRect(150, 150, 75, 23))
        self.pushButton_2.setObjectName("pushButton_2")
        self.pushButton_3 = QtWidgets.QPushButton(self.centralwidget)
        self.pushButton_3.setGeometry(QtCore.QRect(150, 230, 75, 23))
        self.pushButton_3.setObjectName("pushButton_3")
        MainWindow.setCentralWidget(self.centralwidget)
        self.menubar = QtWidgets.QMenuBar(MainWindow)
        self.menubar.setGeometry(QtCore.QRect(0, 0, 384, 23))
        self.menubar.setObjectName("menubar")
        MainWindow.setMenuBar(self.menubar)
        self.statusbar = QtWidgets.QStatusBar(MainWindow)
        self.statusbar.setObjectName("statusbar")
        MainWindow.setStatusBar(self.statusbar)

        self.retranslateUi(MainWindow)
        QtCore.QMetaObject.connectSlotsByName(MainWindow)

    def retranslateUi(self, MainWindow):
        _translate = QtCore.QCoreApplication.translate
        MainWindow.setWindowTitle(_translate("MainWindow", "MainWindow"))
        self.pushButton.setText(_translate("MainWindow", "A"))
        self.pushButton_2.setText(_translate("MainWindow", "B"))
        self.pushButton_3.setText(_translate("MainWindow", "C"))

# if __name__ == '__main__':
#     app = QApplication(sys.argv)
#     MainWindow = QMainWindow()
#     ui = Ui_MainWindow()
#     ui.setupUi(MainWindow)
#     MainWindow.show()
#     sys.exit(app.exec_())
```

7.点击运行后生成如下图片，说明生成成功。

![1553677356390](https://raw.githubusercontent.com/MaoChengEr/maochenger.github.io/master/imgs/1553677356390.png)

​	
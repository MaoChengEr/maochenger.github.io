---
layout: post
comments: true
categories: python
---


关于anaconda中jupyter notebook设置路径问题：  

1.创建.jupyter文件（如果在c:\users\Fred\没有.jupyter文件）    

![1](https://raw.githubusercontent.com/MaoChengEr/maochenger.github.io/master/imgs/1.png)

2.用notepad或者记事本打开.jupyter文件，找到并设置c.NotebookApp.notebook_dir = 'D:\\BaiduNetdiskDownload\\AI'    

![2](https://raw.githubusercontent.com/MaoChengEr/maochenger.github.io/master/imgs/2.png)

3.如果修改路径后问题仍然没有解决，右击Jupter Notebook属性然后修改路径将快捷方式目标后面%homedir%删除即可，其实位置设置成你想要打开的目录文件。  

![3](https://raw.githubusercontent.com/MaoChengEr/maochenger.github.io/master/imgs/3.png)



4.配置文件修改完成后， 以后在jupyter notebook中写的代码等都会保存在自己创建的目录中。
*设置jupyter密码：
from notebook.auth import passwd
passwd()
保存生成的秘钥至配置文件的“c.NotebookApp. notebook_password=‘’ ”
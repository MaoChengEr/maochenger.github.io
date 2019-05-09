---
layout: post
comments: true
categories: Cplus
---
<script type="text/x-mathjax-config">
  MathJax.Hub.Config({
    tex2jax: {
      skipTags: ['script', 'noscript', 'style', 'textarea', 'pre'],
      inlineMath: [['$','$']]
    }
  });
</script>
<script src='https://cdnjs.cloudflare.com/ajax/libs/mathjax/2.7.5/latest.js?config=TeX-MML-AM_CHTML' async></script>

# [C及C++中typedef的简单使用指南](https://www.cnblogs.com/dmego/p/5944169.html)

一.基本解释

　　typedef为C语言的关键字，作用是为一种数据类型定义一个新名字。这里的数据类型包括内部数据类型（int,char等）和自定义的数据类型（struct等）。

　　在编程中使用typedef目的一般有两个，一个是给变量一个易记且意义明确的新名字，另一个是简化一些比较复杂的类型声明。

二．用法

（1）用typedef声明一个新类型名来代替已有的类型名。如：

```c++
typedef int Status  //指定标识符Status代表int类型
typedef double DATE  //指定标识符DATE代表double类型
```

这样下面代码等价：

```c++
int i; double j;
Status i;DATE j;
```

（2）用typedef对数组类型起新名：

```c++
typedef int NUM[100];//声明NUM为整数数组类型，可以包含100个元素
NUM n;//定义n为包含100个整数元素的数组，n就是数组名
```

（3）对一个结构体类型声明一个新名字：

```c++
typedef struct  //在struct之前用了关键字typedef，表示是声明新类型名
{
    int month;
    int day;
    int year;  
} TIME; //TIME是新类型名，但不是新类型，也不是结构体变量名
```

 新声明的新类型名TIME代表上面指定的一个结构体类型，这样就可以用TIME定义该结构体变量，如：

```c++
TIME birthday;
TIME *P //p是指向该结构体类型数据的指针
```

三．注意点

（1）用typedef只是对已经存在的类型增加一个类型名，而没有创造一个新的类型。只是增加了一个新名字，可以用该名字定义变量，比如使用上文中的Status定义变量i；则i变量的类型为int型。

（2）可以用typedef声明新类型名。但是不能用来定义变量

四．优点

　　使用typedef类型名，有利于程序的移植性。有时程序会依赖硬件特性。比如在某个C++系统用2个字节存一个int类型变量，用4个字节存一个long类型变量。而在另一个C++系统中以4个字节存放int类型变量。则把一个C++程序从一个用2个字节存一个int类型变量的C++系统移植到以4个字节存放int类型变量的C++系统时，如果原来用typedef声明int类型,则例如：

```c++
Typedef  int INTEGER ; //原来这样写
Typedef long INTEGER ; //移植后可以改为这样
```

如果不是用typedef声明的，那每一处定义int类型的地方都要改，程序越大，工作量越大。


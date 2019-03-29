---
Layer: posts
Catogery: 
---



### Python之Numpy库

#### 1.Numpy是什么

> numpy——基础，以矩阵为基础的数学计算模块，纯数学存储和处理大型矩阵。 这个是很基础的扩展，其余的扩展都是以此为基础。
> NumPy模块是Python的一种开源的数值计算扩展，是一个用python实现的科学计算包，主要包括：一个具有矢量算术运算和复杂广播能力的快速且节省空间的多维数组，称为ndarray(N-dimensional array object)用于对整组数据进行快速运算的标准数学函数：ufunc(universal functionobject)实用的线性代数、傅里叶变换和随机数生成函数。NumPy和稀疏矩阵的运算包Scipy配合使用更加方便。
> NumPy核心数据结构：ndarray
> NumPy的数组类被称作 ndarray 。通常被称作数组。注意numpy.array和标准Python库类array.array并不相同，后者只处理一维数组和提供少量功能。一种由相同类型的元素组成的多维数组，元素数量是事先给定好的元素的数据类型由dtype(data-type)对象来指定，每个ndarray只有一种dtype类型ndarray的大小固定，创建好数组后数组大小是不会再发生改变的。

#### 2.ndarray创建
可以通过numpy模块中的常用的几个函数进行创建ndarray多维数组对象，主要函数如下：
|常用函数|解释|
| ---- | ---- |
|array函数|接收一个普通的python序列，并将其转换为ndarray|
|zeros函数|创建指定长度或者形状的全零数组|
|ones函数|创建指定长度或者形状的全1数组|
|empty函数|创建一个没有任何具体值的数组(准确地说是创建一些未初始化的ndarray多维数组)|

~~~

~~~


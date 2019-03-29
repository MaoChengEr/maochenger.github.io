---
layout: post
comments: true
categories: python
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

* content
{:toc}
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

**示例：**

~~~python
print('生成全零数组:',np.zeros(3))
print('生成多维的全零数组:',np.zeros((3,3)))

# 生成全零数组: [0. 0. 0.]
# 生成多维的全零数组: [[0. 0. 0.]
#  [0. 0. 0.]
#  [0. 0. 0.]]

print('生成全是1的数组:',np.ones(5))
print('生成多维的全1数组:',np.ones((3,3)))

# 生成全是1的数组: [1. 1. 1. 1. 1.]
# 生成多维的全1数组: [[1. 1. 1.]
#  [1. 1. 1.]
#  [1. 1. 1.]]

print('empty生成数组:',np.empty(4))
print('empty生成多维数组:',np.empty((3,3)))

# empty生成数组: [6.23042070e-307 1.42417221e-306 1.60219306e-306 1.24610383e-306]
# empty生成多维数组: [[0. 0. 0.]
#  [0. 0. 0.]
#  [0. 0. 0.]]
~~~

#### 3.ndarray其他创建函数介绍

##### arange函数

> 类似python的range函数，通过指定开始值、终值和步长来创建一个一维数组，注意：最终创建的数组不包含终值
>
> ```python
> print(np.arange(20))
> # [ 0  1  2  3  4  5  6  7  8  9 10 11 12 13 14 15 16 17 18 19]
> print(np.arange(10,20))
> # [10 11 12 13 14 15 16 17 18 19]
> print(np.arange(10,20,2))
> # [10 12 14 16 18]
> print(np.arange(20,15,-1))
> # [20 19 18 17 16]
> ```

##### linspace函数

> 通过指定开始值、终值和元素个数来创建一个一维数组，数组的数据元素符合等差数列，可以通过endpoint关键字指定是否包含终值，默认包含终值
>
> ```python
> print(np.linspace(0,10,5))
> # [ 0.   2.5  5.   7.5 10. ]
> ```

##### logspace函数

和linspace函数类似，不过创建的是等比数列数组

```python
print(np.logspace(0,2,5))
# [  1.           3.16227766  10.          31.6227766  100.        ]
```

##### numpy.random

使用随机数填充数组，即使用numpy.random中的random()函数来创建0-1之间的随机元素，数组包含的元素数量由参数决定

```python
print(np.random.random((3,2,3)))
# [[[0.77182297 0.01698133 0.48224577]
#   [0.98237646 0.88099001 0.1105487 ]]
# 
#  [[0.76266991 0.59707488 0.1708902 ]
#   [0.06903986 0.09591641 0.45389064]]
# 
#  [[0.010457   0.92246803 0.08712221]
#   [0.96230686 0.00487974 0.1040195 ]]]
```

#### 4.ndarray对象属性

##### 4.1对象属性及其介绍

| 对象 | 解释 |
| ---- | ---- |
|ndim| 数组轴(维度)的个数，轴的个数被称作秩|
|shape| 数组的维度, 例如一个2排3列的矩阵，它的shape属性将是(2,3),这个元组的长度显然是秩，即维度或者ndim属性|
|size| 数组元素的总个数，等于shape属性中元组元素的乘积。|
|dtype|一个用来描述数组中元素类型的对象，可以通过创造或指定dtype使用标准Python类型。不过NumPy提供它自己的数据类型。|
|itemsize| 数组中每个元素的字节大小。例如，一个元素类型为float64的数组itemsiz属性值为8(=64/8),又如，一个元素类型为complex32的数组item属性为4(=32/8).|

```python
a = np.array([
    [1,2,3],
    [4,5,6],
    [7,8,9]
])

print('维度的数量:',a.ndim)
print('数组的形状:',a.shape)
print('数组的元素类型:',a.dtype)
print('数组的元素数量:',a.size)

# 维度的数量: 2
# 数组的形状: (3, 3)
# 数组的元素类型: int32
# 数组的元素数量: 9
```

##### 4.2 ndarray中元素数据类型

创建numpy数组的时候可以通过属性dtype显示指定数据类型，如不指定的情况下，numpy会自动推断出适合的数据类型，所以一般不需要显示给定数据类型。

##### 4.3 Numpy基本数据类型

> 数值型dtype的命名方式为：一个类型名称(eg:int、float等)，后接一个表示各个元素位长的数字，比如Python的float数据类型(双精度浮点值)，需要占用8个字节(64位)，因此在NumPy中记为float64
> 每个数据类型都有一个类型代码，即简写方式
> 如果需要更改一个已经存在的数组的数据类型，可以通过astype方
> 法进行修改从而得到一个新数组。

| 数据类型 |类型简写|说明|
| :--- | ---- | ---- |
|int| |默认整形|
|intc|| 等价于long的整形|
|int8| i1 |字节整形，1个字节，范围:[-128,127]|
|int16| i2 |整形,2个字节,范围:[-32768,32767]|
|int32| i3 |整形,4个字节,范围:[-2^31, 2^31-1]|
|int64 |i4 |整形,8个字节,范围:[-2^63, 2^63-1]|
|uint8| u1 |无符号整形, 1个字节, 范围:[0,255]|
|uint16 |u2| 无符号整形, 2个字节, 范围:[0,65535]|
|uint32 |u3 |无符号整形, 1个字节, 范围:[0, 2^32-1]|
|uint64| u4 |无符号整形, 1个字节, 范围:[0,2^64-1]|
|bool| |以一个字节形成存储的布尔值(True或者False)|
|float|| float64简写形式|
|float16 |f2 |半精度浮点型(2字节)：1符号位+5位指数+10位的小数部分|
|float32| f4或者f| 单精度浮点型(4字节)：1符号位+8位指数+23位的小数部分|
|float64| f8或者d |双精度浮点型(8字节)：1符号位+11位指数+52位的小数部分|
|complex|c16 |complex128的简写形式|
|complex64| c8 |复数，由两个32位的浮点数来表示|
|complex128| c16 |复数，由两个64位的浮点数来表示|
|object |O |Python对象类型|
|String| S| 固定长度的字符串类型(每个字符1个字节)，比如：要创建一个长度为8的字符串，应该使用S8|
|Unicode| U |固定长度的unicode类型的字符串(每个字符占用字节数由平台决定)，长度定义类似String_类型|

**示例：**

```python
d=np.array(['Python','Scale','Jave','C#'])
print(d)
# ['Python' 'Scale' 'Jave' 'C#']
print(d.dtype)
# <U6
e=np.array(['Python','Scale','Jave','C#'],dtype='S8')
print(e)
# [b'Python' b'Scale' b'Jave' b'C#']
print(e.dtype)
# |S8
arr=np.array([129,5,5,6],dtype=np.int32)
print(arr.dtype)
# int32
print(arr)
# [129   5   5   6]
```

##### 4.4 ndarray修改形状

> 对于一个已经存在的ndarray数组对象而言，可以通过修改形状相关的参数/方法从而改变数组的形状。
> 直接修改数组ndarray的shape值, 要求修改后乘积不变。
> 直接使用reshape函数创建一个改变尺寸的新数组，原数组的shape保持不变，但是新数组和原数组共享一个内存空间，也就是修改任何一个数组中的值都会对另外一个产生影响，另外要求新数组的元素个数和原数组一致（还可以降维操作）。
> 当指定某一个轴为-1的时候，表示将根据数组元素的数量自动计算该轴的长度值。

#### 5.ndarray基本操作

##### 5.1数组与标量、数组之间的运算

> 数组不用循环即可对每个元素执行批量的算术运算操作，这个过程叫做矢量化，即用数组表达式代替循环的做法。
> 矢量化数组运算性能比纯Python方式快上一两个数据级。
> 大小相等的两个数组之间的任何算术运算都会将其运算应用到元素级上的
> 操作。
> 元素级操作：在NumPy中，大小相等的数组之间的运算，为元素级运算，即只用于位置相同的元素之间，所得的运算结果组成一个新的数组，运算结果的位置跟操作数位置相同。

```python
#一维数组简单加减乘除
arr1= np.array([1,2,3,4,5])
print(arr1)
print(arr1+4)
print(arr1*4)
print(arr1-4)
print(arr1/4.0)
print(1.0/arr1)
print(arr1**2)
print(2**arr1)

# [1 2 3 4 5]
# [5 6 7 8 9]
# [ 4  8 12 16 20]
# [-3 -2 -1  0  1]
# [0.25 0.5  0.75 1.   1.25]
# [1.         0.5        0.33333333 0.25       0.2       ]
# [ 1  4  9 16 25]
# [ 2  4  8 16 32]

#二维数组简单加减乘除取模
arr1=np.array([[1,2,3],[4,5,6]])
arr2=np.array([[4.6,5.6,7.1],[1.2,3.4,5.6]])
print("=========arr1+arr2==========")
print(arr1+arr2)
print("=========arr1+arr2==========")
print(arr1-arr2)
print("=========arr1+arr2==========")
print(arr1*arr2)
print("=========arr1+arr2==========")
print(arr1/arr2)
print("=========arr1+arr2==========")
print(arr1**arr2)

# =========arr1+arr2==========
# [[ 5.6  7.6 10.1]
#  [ 5.2  8.4 11.6]]
# =========arr1+arr2==========
# [[-3.6 -3.6 -4.1]
#  [ 2.8  1.6  0.4]]
# =========arr1+arr2==========
# [[ 4.6 11.2 21.3]
#  [ 4.8 17.  33.6]]
# =========arr1+arr2==========
# [[0.2173913  0.35714286 0.42253521]
#  [3.33333333 1.47058824 1.07142857]]
# =========arr1+arr2==========
# [[1.00000000e+00 4.85029301e+01 2.44096138e+03]
#  [5.27803164e+00 2.37956742e+02 2.27848935e+04]]
```

数组的广播:如果两个数组的后缘维度(即：从末尾开始算起的维度)的轴长相符或其中一方的长度为1，则认为它们是广播兼容的，广播会在缺失和(或)长度为1的轴上进行.

```python
arr2=np.random.randint(1,9,(2,3))
print(arr2)
# [[7 7 4]
#  [6 3 4]]
arr3=np.array([2,3,4])
print(arr3)
# [2 3 4]
print(arr2.shape)
# (2, 3)
print(arr3.shape)
# (3,)
print(arr2+arr3)
# [[ 3  6  6]
#  [ 8  7 11]]
```

##### 5.2数组的矩阵积(matrix product)

矩阵：多维数组即矩阵
矩阵积(matrix product)：两个二维矩阵(行和列的矩阵)满足第一个矩阵的列数与第二个矩阵的行数相同，那么可以进行矩阵的乘法，即矩阵积，矩阵积不是元素级的运算。也称为点积、数量积。
$$
A=\begin{vmatrix}
a_{11} \quad a_{12} \quad a_{13} \\ 
a_{21} \quad a_{22} \quad a_{23} \\ 
a_{31} \quad a_{32} \quad a_{33} 
\end{vmatrix}\times 
B=\begin{vmatrix} 
b_{11}\quad b_{12}\\
b_{21}\quad b_{22}\\
b_{31}\quad b_{32}
\end{vmatrix} = 
C=\begin{vmatrix} 
c_{11}\quad c_{12}\\
c_{21}\quad c_{22}\\
c_{31}\quad c_{32}
\end{vmatrix}\\
C_{ij}=\sum_{k=1}^3 a_{ik}*b_{kj};1\leq i \leq 3;1\leq j \leq 2
$$

##### 5.3数组的索引与切片

索引：

花式索引： 通过花式索引获取的新数组是一个副本，新数组修改不会影响原数组

布尔索引：

##### 5.4数组的转置与轴对换

> 数组转置是指将shape进行重置操作，并将其值重置为原始shape元组的倒置，比如原始的shape值为:(2,3,4)，那么转置后的新元组的shape的值为: (4,3,2)
> 对于二维数组而言(矩阵)数组的转置其实就是矩阵的转置
> 可以通过调用数组的transpose函数或者T属性进行数组转置操作

##### 5.5数组的拉伸与合并

> 数组拉伸np.tile（A，rep）函数可以将数组A进行拉伸，沿着A的维度重复rep次
> 对于ndarray数组而言，多个数组可以执行合并操作，合并的方式有多种。
> Stack(arrays,axis=0):沿着新的轴加入一系列数组
> vstack（）：堆栈数组垂直顺序（行）
> hstack（）：堆栈数组水平顺序（列）。

##### 5.6通用函数：快速的元素级数组成函数

ufunc：numpy模块中对ndarray中数据进行快速元素级运算的函数，也可以看做是简单的函数(接受一个或多个标量值，并产生一个或多个标量值)的矢量化包装器。
主要包括一元函数和二元函数

|一元ufunc|描述|调用方式|
| ---- | ---- | ---- |
|abs, fabs| 计算整数、浮点数或者复数的绝对值，对于非复数，可以使用更快的fabs|np.abs(arr)，np.fabs(arr)|
|sqrt |计算各个元素的平方根，相当于arr ** 0.5， 要求arr的每个元素必须是非负数|np.sqrt(arr)|
|square| 计算各个元素的平方，相当于arr ** 2 np.square(arr)exp 计算各个元素的指数e的x次方 |np.exp(arr)|
|log、log10、log2、log1p|分别计算自然对数、底数为10的log、底数为2的log以及log(1+x)；要求arr中的每个元素必须为正数|np.log(arr)，np.log10(arr)，np.log2(arr)，np.log1p(arr)|
|sign |计算各个元素的正负号: 1 正数，0：零，-1：负数| np.sign(arr)|
|ceil |计算各个元素的ceiling值，即大于等于该值的最小整数 |np.ceil(arr)|
|floor| 计算各个元素的floor值，即小于等于该值的最大整数| np.floor(arr)|
|rint| 将各个元素值四舍五入到最接近的整数，保留dtype的类型 |np.rint(arr)|
|modf| 将数组中元素的小数位和整数位以两部分独立数组的形式返回 np.modf(arr)|
|isnan |返回一个表示“那些值是NaN(不是一个数字)”的布尔类型数组 |np.isnan(arr)|
|isfinite、isinf |分别一个表示”那些元素是有穷的(非inf、非NaN)”或者“那些元素是无穷的”的布尔型数组|np.isfinite(arr)，np.isinf(arr)|
|cos、cosh、sin、sinh、tan、tanh|普通以及双曲型三角函数 |np.cos(arr),np.sin(arr),np.tan(arr)|
|arccos、arccosh、arcsin、arcsinh、arctan、arctanh|反三角函数|np.arccos(arr)np.arcsin(arr)，np.arctan(arr)|

|二元ufunc|描述|调用方式|
| ---- | ---- | ---- |
|mod|元素级的求模计算（除法取余）| np.mod(arr1,arr2)|
|dot |求两个数组的点积| np.dot(arr1,arr2)|
|greater、greater_equal、less、less_equal、equal、not_equal|执行元素级别的比较运算，最终返回一个布尔型数组| np.greater(arr1, arr2)|np.less(arr1, arr2)，np.equal(arr1, arr2)|
|logical_and、logical_or、logical_xor|执行元素级别的布尔逻辑运算，相当于中缀运算符&、|、^|np.logical_and(arr1,arr2)，np.logical_or(arr1,arr2)，np.logical_xor(arr1,arr2)|
|power| 求解对数组中的每个元素进行给定次数的指数值，类似于: arr ** 3|np.power(arr, 3)|

##### 5.7聚合函数

聚合函数是对一组值(eg一个数组)进行操作，返回一个单一值作为结果的函数。当然聚合函数也可以指定对某个具体的轴进行数据聚合操作；常见的聚合操作有：平均值、最大值、最小值、总体标准偏差等等

##### 5.8np.where函数

np.where函数是三元表达式x if condition else y的矢量化版本

~~~python
arr1 = np.array([1,3,5,2,4])
arr2 = np.array([2,2,6,3,3])
print(arr1)
print(arr2)
#[1 3 5 2 4]
#[2 2 6 3 3]
condition = arr1<arr2
print(condition)
#[ True, False,  True,  True, False]
new_array = [x if c else y  for x,y,c in zip(arr1,arr2,condition)]
print(new_array)
#[1, 2, 5, 2, 3]
print(np.where([ True, False,  True,  True, False],[1,3,5,2,4],[2,2,6,3,3]))
#[1, 2, 5, 2, 3]
print(np.where([[True, False], [True, True]],[[1, 2], [3, 4]],[[9, 8], [7, 6]]))
#[1, 1, 2, 3, 4, 2, 3, 1, 4]
~~~



##### 5.9np.unique函数

np.unique函数的主要作用是将数组中的元素进行去重操作(也就是只保存不重复的数据)

~~~python
arr = np.random.randint(1,5,9)
#[1, 1, 2, 3, 4, 2, 3, 1, 4]
print(arr)
#[1, 2, 3, 4]
~~~












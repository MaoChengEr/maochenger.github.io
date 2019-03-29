---
layout: post
comments: true
categories: python
---

* content
{:toc}
### Python之Pandas库

#### 1.Pandas介绍

> ##### 1.1什么是Pandas
>
> pandas是一种Python数据分析的利器，是一个开源的数据分析包，最初是应用于金融数据分析工具而开发出来的，因此pandas为时间序列分析提供了很好的支持。pandas是PyData项目的一部分。

##### 1.2pandas引入

~~~python
from pandas import Series, DataFrame
import pandas as pd
~~~

#### 2.pandas基本数据结构

> pandas中主要有两种数据结构，分别是：Series和DataFrame。
> Series：一种类似于一维数组的对象，是由一组数据(各种NumPy数据类型)以及一组与之相关的数据标签(即索引)组成。仅由一组数据也可产生简单的Series对象。注意：Series中的索引值是可以重复的。
> DataFrame：一个表格型的数据结构，包含有一组有序的列，每列可以是不同的值类型(数值、字符串、布尔型等)，DataFrame即有行索引也有列索引，可以被看做是由Series组成的字典。

##### 2.1 Series

###### 2.1.1Series：通过一维数组或者列表创建

~~~python
ser01 = pd.Series([1,2,3,4])
# 0    1
# 1    2
# 2    3
# 3    4
# dtype: int64

ser02 = pd.Series(np.random.randint(1,9,5))
# 0    4
# 1    1
# 2    5
# 3    1
# 4    4
# dtype: int32
~~~

###### 2.1.2Series：通过字典的方式创建

~~~python
dic = {
    'a':1,
    'b':2,
    'c':3
}
ser03 = pd.Series(dic)
# a    1
# b    2
# c    3
# dtype: int64
~~~

###### 2.1.3常见Series的属性

|编号|属性或者方法|描述|
| ---- | ---- | ---- |
|1|axes|返回轴标签列表|
|2| dtype|返回独享的和数据类型|
|3|empty|如果系列为空，则返回True|
|4|ndim|返回底层数据的维数，默认定义为：1|
|5|size|返回基础数据中的元素数|
|6|values|将邪猎作为ndarray返回|
|7|head()|返回前N行|
|8|tail()|返回最后n行|

###### 2.1.4Series值的获取

> Series值的获取主要有两种方式：
> 	通过方括号+索引的方式读取对应索引的数据，有可能返回多条数据
> 	通过方括号+下标值的方式读取对应下标值的数据，下标值的取值范围为：
> 	[0，len(Series.values))；另外下标值也可以是负数，表示从右往左获取数据
> Series获取多个值的方式类似NumPy中的ndarray的切片操作，通过方括号+下标值/索引值+冒号(:)的形式来截取series对象中的一部分数

###### 2.1.5Series的运算

NumPy中的数组运算，在Series中都保留了，均可以使用，并且Series进行数组运算的时候，索引与值之间的映射关系不会发生改变。
注意：其实在操作Series的时候，基本上可以把Series看成NumPy中的ndarray数组来进行操作。ndarray数组的绝大多数操作都可以应用到Series上。

###### 2.1.6Series自动对齐

当多个series对象之间进行运算的时候，如果不同series之间具有不同的索引值，那么运算会自动对齐相同索引值的数据，如果某个series没有某个索引值，那么最终结果会赋值为NaN。

###### 2.1.7Series缺失值检测

pandas中的isnull和notnull两个函数可以用于在Series中检测缺失值，这两个函数的返回时一个布尔类型的Series

##### 2.2DataFrame

> DataFrame是Python中Pandas库中的一种数据结构，它类似excel，是一种**二维表**。

###### 2.2.1DataFrame: 通过列表或者二维数组创建

Pandas中的DataFrame可以使用一下构造函数创建-pandas.DataFrame(data,index,columns,dtype,copy)

|编号|参数|描述|
| ---- | ---- | ---- |
|1|data|数据才去各种性坏死，如：ndarray,series,map,lists,dict,constant和另一个DataFrame|
|2|index|对于行标签，要用于结果帧的索引是可选缺省值np.arange(n),如果没有传递索引值|
|3|columns|对于列标签，可选的默认语法是-np.arange(n),这只有在没有索引传递的情况下才是这样|
|4|dtype|每列的数据类型|
|5|copy|如果默认值为False，则此命令（或任何它）用于赋值数据|

~~~python
#通过列表创建
li = [[1,2,3,4],[5,6,7,8]]

df01 = pd.DataFrame(li)

#通过Series创建
ser01 = pd.Series([1,2,3,4])
ser02 = pd.Series([1,2,3,4])
df02 = pd.DataFrame([ser01,ser02])

#以上两种产出结果都是：
#	0	1	2	3
#0	1	2	3	4
#1	5	6	7	8
~~~





###### 2.2.2DataFrame: 通过字典的方式创建

~~~
#字典创建
dic = {
    'name':['joe','anne','yilianna'],   #  key 就是 列索引
    'age':[18,19,20],
    'class':1                          # 整列数据会被标量填充
} 
df03 = pd.DataFrame(dic)
~~~

![1553844515578](https://raw.githubusercontent.com/MaoChengEr/maochenger.github.io/master/imgs/1553844515578.png)

###### 2.2.3索引对象

> 不管是Series还是DataFrame对象，都有索引对象。
> 索引对象负责管理轴标签和其它元数据(eg：轴名称等等)
> 通过索引可以从Series、DataFrame中获取值或者对某个索引值进行重新赋值
> Series或者DataFrame的自动对齐功能是通过索引实现的

###### 2.2.4DataFrame数据获取

> 可以直接通过列索引获取指定列的数据， eg: df[column_name]
> 如果需要获取指定行的数据的话，需要通过ix方法来获取对应行索引的行数据，eg: df.ix[index_name] loc、iloc

#### 3.Pandas基本功能

##### 3.1数据文件读取/文本数据读取与文本存储

通过pandas提供的read_xxx相关的函数可以读取文件中的数据，并形成DataFrame,常用的数据读取方法为：read_csv，主要可以读取文本类型的数据3.2索引、选取和数据过滤

~~~python
import pandas as pd
#文件读取，一般读取的格式都为.csv格式
pd.read_csv(PATH,sep=';',header=None)

#文件存储
df.to_csv(PATH,sep=':',header=None)
~~~

文件的过滤获取：通过DataFrame的相关方式可以获取对应的列或者数据形成一个新的DataFrame, 方便后续进行统计计算。

缺省值NaN处理方法：

​	对于DataFrame/Series中的NaN一般采取的方式为删除对应的列/行或者填充一个默认值

|方法|说明|
| ---- | ---- |
|dropna|根据标签的值是否存在缺失数据进行过滤（删除），可以通过阈值的调节缺失值的容忍度|
|fillna|用指定值或者插值的方式填充缺失数据，比如：ffill或者bfill|
|isnull|返回一个含有布尔值得对象，这些布尔值表示那些值是缺失值NAN|
|notnull|isnull的否定形式|

~~~python
#缺失值处理
df01 = pd.DataFrame(np.random.randint(1,9,(4,4)),index = list('ABCD'),columns = list('abcd'))
df01.loc['B','c'] = np.NaN
df01.loc['C','b'] = np.NaN
df01
~~~

![1553846334601](https://raw.githubusercontent.com/MaoChengEr/maochenger.github.io/master/imgs/1553846334601.png)

~~~python
#dropna
df01.dropna()  # 默认会删除带有 NaN 的行  只要包含一个就整行删除
~~~

![1553846403690](https://raw.githubusercontent.com/MaoChengEr/maochenger.github.io/master/imgs/1553846403690.png)

~~~python
df01.dropna(axis = 1)    # 删除列中带有NaN的列
~~~

![1553846773941](https://raw.githubusercontent.com/MaoChengEr/maochenger.github.io/master/imgs/1553846773941.png)

~~~python
# 设置阀值
df01 = df01.dropna(how = 'all')   # 只删除整行为  nan的行
~~~

![1553846816263](https://raw.githubusercontent.com/MaoChengEr/maochenger.github.io/master/imgs/1553846816263.png)

~~~python
df01.loc['E'] = np.NaN
~~~

![1553846967923](https://raw.githubusercontent.com/MaoChengEr/maochenger.github.io/master/imgs/1553846967923.png)

~~~python
df01.fillna(0)  # 将所有的 nan 数据替换成了 0
~~~

![1553847003504](https://raw.githubusercontent.com/MaoChengEr/maochenger.github.io/master/imgs/1553847003504.png)

~~~python
df01.fillna(method = 'ffill')   # 根据前一个值进行替换
~~~

![1553847043076](https://raw.githubusercontent.com/MaoChengEr/maochenger.github.io/master/imgs/1553847043076.png)

~~~python
df01.fillna(method = 'bfill')   # 根据后一个值进行替换
~~~

![1553847090487](https://raw.githubusercontent.com/MaoChengEr/maochenger.github.io/master/imgs/1553847090487.png)

~~~python
df01.fillna({'b':100,'c':200})   # 根据列进行替换
~~~

![1553847112244](https://raw.githubusercontent.com/MaoChengEr/maochenger.github.io/master/imgs/1553847112244.png)

~~~python
df01.replace({np.NaN:'hahah',1:'heiheih'})   # 根据值进行替换
~~~

![1553847133749](https://raw.githubusercontent.com/MaoChengEr/maochenger.github.io/master/imgs/1553847133749.png)

##### 3.3算法运算和数据对齐

|方法|说明|
| ---- | ---- |
|count|计算非NA值的数量|
|describe| 针对Series或各DataFrame列计算总统计值|
|min/max |计算最大值、最小值|
|idxmin、idxmax |计算能够获取到最小值和最大值的索引位置(整数)|
|argmin、argmax| 计算能够获取到最小值和最大值的索引值|
|quantile| 计算样本的分位数(0到1)|
|sum| 值的总和|
|mean |值的平均数|
|median |值的中位数|
|mad| 根据平均值计算平均绝对距离差|
|var |样本数值的方差|
|std|样本标准偏差|
|cumsum| 样本值的累计和|
|cummin、cummax| 样本的累计最小值、最大值|
|cumprod |样本值的累计积|
|pct_change| 计算百分数变化|

##### 3.4函数的应用

##### 3.5层次索引

> 在某一个方向拥有多个(两个及两个以上)索引级别
> 通过层次化索引，pandas能够以较低维度形式处理高纬度的数据
> 通过层次化索引，可以按照层次统计数据
> 层次索引包括Series层次索引和DataFrame层次索引

##### 3.6排序

###### 3.6.1Pandas排序之sort_index

> sort_index 对行或列索引进行排序。
> Series 的 sort_index(ascending=True) 方法可以对 index 进行排序操作，ascending 参数用于控制升序或降序，默认为升序。
> 在 DataFrame 上，.sort_index(axis=0, ascending=True) 方法多了一个轴向的选择参数

###### 3.6.2Pandas排序之sort_values

> 对Series按值进行排序, 排序时，任何缺失值默认都会被放到Series的末尾。

###### 3.6.3Pandas排序之rank

>排名（ranking ） 跟排序关系密切， 且它会增设一个排名值（从1开始， 一直到数组中有效数据的数量）。
>它跟numpy.argsort产生的间接根据索引排序差不多， 只不过它可以根据某种规则破坏平级关系。
>默认情况下， rank是通过”为各组分配一个平均排名“的方式破坏平级关系的。

##### 3.7时间序列

在pandas中有一个非常常用的函数date_range，尤其是在处理时间序列数据时，这个函数的作用就是产生一个 DatetimeIndex ，就是时间序列数据的索引

> pandas.date_range(start=None, end=None, periods=None, freq=’D’, tz=None, normalize=False, name=None,closed=None, **kwargs)
> start：string或datetime-like，默认值是None，表示日期的起点。
> end：string或datetime-like，默认值是None，表示日期的终点。
> periods：integer或None，默认值是None，表示你要从这个函数产生多少个日期索引值；如果是None的话，那么start和end必须不能为None。
> freq：string或DateOffset，默认值是’D’，表示以自然日为单位，这个参数用来指定计时单位，比如’5H’表示每隔5个小时计算一次。
> tz：string或None，表示时区，例如：’Asia/Hong_Kong’。
> normalize：bool，默认值为False，如果为True的话，那么在产生时间索引值之前会先把start和end都转化为当日的午夜0点。
> name：str，默认值为None，给返回的时间索引指定一个名字。
> closed：string或者None，默认值为None，表示start和end这个区间端点是否包含在区间内，可以有三个值，’left’表示左闭右开区间，’right’表示左开右闭区间，None表示两边都是闭区间。

##### 3.8数据合并

###### 3.8.1pandas.merge 可根据一个或多个键将不同 DataFrame 中的行连接起来。

> on=None 用于显示指定列名（键名），如果该列在两个对象上的列名不同，则可以通过 left_on=None,
> right_on=None 来分别指定。或者想直接使用行索引作为连接键的话，就将 left_index=False,
> right_index=False 设为 True。
> how='inner' 参数指的是当左右两个对象中存在不重合的键时，取结果的方式：inner 代表交集；outer代表并集；left 和 right 分别为取一边。
> suffixes=('_x','_y') 指的是当左右对象中存在除连接键外的同名列时，结果集中的区分方式，可以各加一个小尾巴。
> 对于多对多连接，结果采用的是行的笛卡尔积。

###### 3.8.2pandas.concat 可以沿着一条轴将多个对象堆叠到一起

> objs: series，dataframe或者是panel构成的序列lsit
> axis： 需要合并链接的轴，0是行，1是列
> join：连接的方式 inner，或者outer

##### 3.9分组聚合

###### 3.9.1Pandas分组

groupby 对DataFrame进行数据分组，传入列名列表或者Series序列对象，返回生成一个GroupBy对象。它实际上还没有进行任何计算。
GroupBy对象是一个迭代对象，每次迭代结果是一个元组。
元组的第一个元素是该组的名称(就是groupby的列的元素名称)。
第二个元素是该组的具体信息，是一个数据框。
索引是以前的数据框的总索引。

###### 3.9.2Pandas聚合之apply

apply 是 pandas 库的一个很重要的函数，多和 groupby 函数一起用，也可以直接用于 DataFrame 和 Series 对象。主要用于数据聚合运算，可以很方便的对分组进行现有的运算和自定义的运算。

##### 3.10数据透视

~~~python
df = pd.DataFrame({
    'kill':[1,2,3,4,5],
    'address':['皮卡多','圣马丁','皮卡多','圣马丁','皮卡多'],
    'help':[3,4,2,5,2],
    'sex':['m','w','m','m','w']
})
~~~

![1553847779419](https://raw.githubusercontent.com/MaoChengEr/maochenger.github.io/master/imgs/1553847779419.png)

~~~python
df.pivot_table(values = ['kill','help'],index = ['address'],aggfunc = np.mean)
# 通过index 进行 分组 查看 values 中的字段 的 aggfunc 值
~~~

![1553847805642](https://raw.githubusercontent.com/MaoChengEr/maochenger.github.io/master/imgs/1553847805642.png)

~~~python
df.groupby('address')['kill','help'].mean()
~~~

![1553847839940](https://raw.githubusercontent.com/MaoChengEr/maochenger.github.io/master/imgs/1553847839940.png)

~~~python
df.pivot_table(values = ['kill','help'],index = ['address'],aggfunc = [np.mean,np.max,np.min])
~~~

![1553847911342](https://raw.githubusercontent.com/MaoChengEr/maochenger.github.io/master/imgs/1553847911342.png)

~~~python
df.pivot_table(values = ['kill','help'],index = ['address'],columns = ['sex'],aggfunc = np.mean)
~~~

![1553847934899](https://raw.githubusercontent.com/MaoChengEr/maochenger.github.io/master/imgs/1553847934899.png)


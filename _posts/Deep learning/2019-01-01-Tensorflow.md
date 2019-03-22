---
layout: post
comments: true
categories: 深度学习
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

### Tensorflow

~~~python
#1.tensorflow
import tensorflow as tf
#
# m1=tf.constant([3,5])
# m2=tf.constant([4,5])
# result=tf.add(m1,m2)

# sess=tf.Session()
# print(sess.run(result))
# sess.close()

#无需显示close释放资源
# with tf.Session() as sess:
#     res = sess.run([result])
# print(res)

#指定cpu或者gpu等计算分布执行图的运算过程
# with  tf.Session() as sess:
#     with tf.device("/gpu:2"):
#         m1=tf.constant([3,5])
#         m2=tf.constant([4,5])
#         result=tf.add(m1,m2)

#使用as_default生成默认会话,通过eval直接输出变量的内容
# sess=tf.Session()
# with sess.as_default():
#     print(result.eval())


#在jupyter或Ipython等python交互环境开发，针对交互式换将开发的方法InterativeSession()
# sess = tf.InteractiveSession()
# print(result.eval())

'''
图模型的好处：1.节约系统开销，提高资源利用率，可以更加高效的进行运算。
             2.这种结构有利于我们提取中间节点的结果,方便以后利用中间节点进行其他运算
             3.对于分布式结构特别友好，可以分配给多个cpu或者gpu同时进行，提高运算效率
             4.这种图模型分成了很多个子环节。这种结构更有利于求导。
'''


#2.tensor
'''
Tensor（张量）是tensorflow中最重要的数据结构，用来表示Tensorflow程序中的多有数据。
Tensor本事广泛应用在物理、数学领域中的一个物理量。
Tensor可以理解为N维矩阵（N组数组）。其中零维张量表示的是一个矩阵；同理，N维张量也就是N维矩阵。
'''

# a=tf.constant([[2.0,3.0]],name='a')
# b=tf.constant([[1.0],[4.0]],name='b')
# result=tf.matmul(a,b,name='mul')
# print(result)

'''
Notice:要注意张量的类型一致，否则会出现类型不匹配的错误。
'''

#常量、变量以及占位符
'''
constant:constant有五个参数，分别为Value，name，dtype，shape和verify_shape。
其中Value是必须值。verify_shape为检查Value的真实shape的一致性。
此外Tensorflow还提供了一些常见的初始化，tf.zeros,tf.ones,tf.fill,tf.linspace,tf.range等
'''
# a=tf.zeros([2,2],tf.float32)
# b=tf.zeros_like(a,optimize=True)
# with tf.Session() as sess:
#     with tf.device("/cpu:10"):
#         print(sess.run(a))
#         print(sess.run(b))

#Tensorflow还提供了一些生成随机变量的张量，方便初始化一些随机值。
#比如：tf.random_normal(),tf.truncated_normal(),tf.random_uniform().tf.random_shuffle()等

# random_num=tf.random_normal([2,3],mean=1,stddev=4,dtype=tf.float32,seed=None,name='rnum')
# with tf.Session() as sess:
#     print(sess.run(random_num))

"""
除了常量constant()，变量variable()也是在Tensorflow中经常使用到的函数，变量的作用
是保存和更新参数，执行图模型时，一定要对变量进行初始化，初始化后的变量才能拿来用，变量的
使用包括创建，初始化，保存，加载等操作。
"""

#第一步创建变量
A = tf.Variable(3,name='number')
B = tf.Variable([1,3],name='vector')
C = tf.Variable([[0,1],[1,2]],name='matrix')
D = tf.Variable(tf.zeros([100]),name='zero')
E = tf.Variable(tf.random_normal([2,3],mean=1,stddev=2,dtype=tf.float32))

#第二步初始化变量
# init=tf.global_variables_initializer()
# with tf.Session() as sess:
#     sess.run(init)
#
# #初始化变量的子集
# init_subset=tf.variables_initializer([B,C],name='init_subset')
# with tf.Session() as sess:
#     sess.run(init_subset)
#
# #初始化单个变量
# init_var=tf.Variable(tf.zeros([2,5]))
# with tf.Session() as sess:
#     sess.run(init_var.initializer)

#第三步变量的保存
'''
在训练模型后，我们通常希望保存训练后的结果，以便下次再使用时方便日后查看。
这时就使用到了tf.train.Saver()方法创建一个Saver的管理器，来保存计算图模型中所有的变量
'''
# var1 = tf.Variable([1,3],name='v1')
# var2 = tf.Variable([2,4],name='v2')
# #对全部变量进行初始化
# init=tf.initialize_all_variables()
# #调用saver()存储方法
# saver=tf.train.Saver()
# #执行图模型
# with tf.Session() as sess:
#     sess.run(init)
#     #设置存储路径
#     save_path=saver.save(sess,'test/save.ckpt')

'''
notice:注意save.ckpt是一个二进制文件，Saver存储器提供了向该二进制文件保存变量和恢复变量的方法，
保存变量就是程序中save()方法，保存的内容是从变量名到tensor值的映射关系。
此外，Saver提供了一个内置的计数器自动为checkpoint文件编号。这就支持训练模型在任意步骤多次保存。
此外，还可以通过global_step参数自动对文件进行编号。
'''

#保存变量的恢复
# module_file=tf.train.latest_checkpoint('test/')
# with tf.Session() as sess:
#     saver.restore(sess,module_file)
#     print('Module restore')

'''
notice:注意变量的获取是通过restore()方法，该方法有两个参数，分别是session和获取变量文件的位置。
我们还可以通过latest_checkpoint()方法，获取到该目录下最近一次保存的模型。
'''

#eval函数和placeholder函数
'''
Tensotflow中还有一个非常重要的常用函数--placeholder。placeholder是一个数据化的容器，它与变量
最大的不同在于placeholder定义的是一个模板，这样我们就可以session运行阶段，利用feed_dict的字典
结构给placeholder填充具体的内容，而无需每次提前好变量值，大大提高了代码的利用率。
'''
a=tf.placeholder(tf.float32,shape=[2],name=None)
b=tf.constant([6,4],tf.float32)
c=tf.add(a,b)
with tf.Session() as sess:
    print(sess.run(c,feed_dict={a:[10,10]}))
~~~


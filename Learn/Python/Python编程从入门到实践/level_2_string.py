
# 定义自符串
message = "this is String Test."
# 输出字符串
print(message)
# 使字符串 首字母大写，其余不变
print(message.title())
# 使字符串 全大写
print(message.upper())
# 使字符串 全小写
print(message.lower())

# 字符串 拼接, 使用 + 号
message_2 = message + "  + string    "
print(message_2)
# 字符串 拼接, 使用 join. [str对象自带的join()方法接收一个序列参数。而后设置统一的间隔符。普遍来说，拼接长度不超过20时，这种方式效率是最高的。]
message_3 = ['Hello', 'World']
print(' '.join(message_3))
print('|'.join(message_3))
# 字符串 拼接 使用 format 格式化. [format()方法使用{}来做占位]
message_4 = "Hello {} Hello {}"
message_4_1 = 'Python'
print(message_4.format('World', message_4_1))
# 字符串 拼接 使用 f-string 格式化. []
print(f'Hello Test, My name is {message_4_1}')
# 字符串 拼接 使用 () 号. [这种方式每一对引号为一部分，相邻引号对之间可以使用任意空格分开。并且，这种方式得到的字符串的数据类型就是str]
# [这种方式的缺点是，()内不能使用变量，如果有变量，就不能有其他字符串常量，并且，变量最多也只能有一个。即s = (str1)，str1是变量，这样是合理的。s = (str1 str2)和s = (str1 'Hello')都是不行的，会报错。]
message_5 = ('Hello' '-' 'China')
print(message_5)
message_6 = 1
print((message_6))  # 利用()号，顺利将num转换成str.

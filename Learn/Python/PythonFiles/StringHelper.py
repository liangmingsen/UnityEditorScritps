# -*- coding:utf-8 -*-
import os
import sys


## 向后截取字符串
## path = 字符串
## divide_string = 从查找的字符串开始往后截取
## 返回截取后的新字符串
def cut_out_string_backward(path, divide_string):
	## 获取字符串长度
	str_len = get_string_len(divide_string)
	idx = path.find(divide_string)
	##取字符串
	new_path = path[idx+str_len:]
	return new_path

## 向前截取字符串
## path = 字符串
## divide_string = 从头开始到查找的字符串
## 返回截取后的新字符串
def cut_out_string_forward(path, divide_string):
	idx = path.find(divide_string)
	##取字符串
	new_path = path[0:idx]
	return new_path

##取字符串长度
def get_string_len(path):
	return len(path)

##从下标0开始,返回找到的第一个val的下标。如果没找到返回-1
def get_find_forward(path, val):	
	return path.find(val)

##从未尾开始，返回找到的第一个val的下标。如果没找到返回-1
def get_find_backward(path, val):
	return path.rfind(val)
	

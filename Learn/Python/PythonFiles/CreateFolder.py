# -*- coding:utf-8 -*-

import os
import sys
import FileHelper
import StringHelper

## 递归创建目录
if __name__ == '__main__':
	source_path = "E:\LMSGame\wl\wlgame\wlgame\chient\Assets\Main\Scripts"
	target_path = "E:\\LMSGit\\LMS\\Laya\\Client\\src\\GameClient\\"
	
	## 从外到内，递归遍历所有文件夹及文件
	for (root, dirs, files) in os.walk(source_path):
		for d in dirs:
			dpath = os.path.join(root,d)
			new_path = StringHelper.cut_out_string_backward(dpath, "\\Scripts\\")
			
			print(new_path)
			#FileHelper.make_dirs(new_path)

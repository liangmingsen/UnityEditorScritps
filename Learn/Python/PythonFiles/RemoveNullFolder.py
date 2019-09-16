# -*- coding:utf-8 -*-

import os
import sys
import FileHelper

## 从内到外，递归遍历，删除空的文件夹	
## 好奇怪，要执行多次才能清理干净
if __name__ == '__main__':
	target_path = "E:\\LMSGit\\LMS\\Laya\\Client\\src\\GameClient\\"
	
	FileHelper.remove_null_folder(target_path)

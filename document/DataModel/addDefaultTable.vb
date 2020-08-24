Option   Explicit    
ValidationMode   =   True    
InteractiveMode   =   im_Batch    
  
Dim   mdl,table,col   '   the   current   model    
  
'   get   the   current   active   model    
Set   mdl   =   ActiveModel    
If   (mdl   Is   Nothing)   Then    
      MsgBox   "There   is   no   current   Model "    
ElseIf   Not   mdl.IsKindOf(PdPDM.cls_Model)   Then    
      MsgBox   "The   current   model   is   not   an   Physical   Data   model. "    
End if  

set table = mdl.Tables.CreateNew
table.Name = "咨询"
table.Code = "Consult.Question"
table.Comment = "咨询"

Set col = table.columns.CreateNew 
col.name = "标识"
col.code = "Id"
col.comment = "标识"
col.DataType = "char(36)"
col.Primary = True
set col = nothing

Set col = table.columns.CreateNew 
col.name = "Version"
col.code = "Version"
col.comment = "Version"
col.DataType = "longblob"
set col = nothing

Set col = table.columns.CreateNew 
col.name = "创建时间"
col.code = "CreationTime"
col.comment = "创建时间"
col.DataType = "datetime(6)"
set col = nothing

Set col = table.columns.CreateNew 
col.name = "创建人标识"
col.code = "CreatorId"
col.comment = "创建人标识"
col.DataType = "char(36)"
set col = nothing

Set col = table.columns.CreateNew 
col.name = "最后修改时间"
col.code = "LastModificationTime"
col.comment = "最后修改时间"
col.DataType = "datetime(6)"
set col = nothing

Set col = table.columns.CreateNew 
col.name = "最后修改人标识"
col.code = "LastModifierId"
col.comment = "最后修改人标识"
col.DataType = "char(36)"
set col = nothing
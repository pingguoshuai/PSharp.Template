

<template>
  <a-card :bordered="false">
    <div class="table-page-search-wrapper">
      <a-form layout="inline">
        <a-row :gutter="48">
            
          <a-col :md="8" :sm="24">
            <a-form-item label="ParentId">
              <a-input v-model="queryParam.parentId" placeholder=""/>
            </a-form-item>
          </a-col>
          <a-col :md="8" :sm="24">
            <a-form-item label="名称">
              <a-input v-model="queryParam.name" placeholder=""/>
            </a-form-item>
          </a-col>
          <a-col :md="8" :sm="24">
            <a-form-item label="图片">
              <a-input v-model="queryParam.iconId" placeholder=""/>
            </a-form-item>
          </a-col>
          <a-col :md="8" :sm="24">
            <a-form-item label="类型">
              <a-input v-model="queryParam.typeId" placeholder=""/>
            </a-form-item>
          </a-col>
          <a-col :md="8" :sm="24">
            <a-form-item label="自定义名称">
              <a-input v-model="queryParam.diyName" placeholder=""/>
            </a-form-item>
          </a-col>
          <a-col :md="8" :sm="24">
            <a-form-item label="是否可投稿">
              <a-select v-model="queryParam.isContribute" placeholder="请选择" default-value="">
                <a-select-option value="">全部</a-select-option>
                <a-select-option value="true">是</a-select-option>
                <a-select-option value="false">否</a-select-option>
              </a-select>
            </a-form-item>
          </a-col>
          <a-col :md="8" :sm="24">
            <a-form-item label="导航显示">
              <a-select v-model="queryParam.isNav" placeholder="请选择" default-value="">
                <a-select-option value="">全部</a-select-option>
                <a-select-option value="true">是</a-select-option>
                <a-select-option value="false">否</a-select-option>
              </a-select>
            </a-form-item>
          </a-col>
          <a-col :md="8" :sm="24">
            <a-form-item label="状态">
              <a-select v-model="queryParam.status" placeholder="请选择" default-value="">
                <a-select-option value="">全部</a-select-option>
                <a-select-option value="true">是</a-select-option>
                <a-select-option value="false">否</a-select-option>
              </a-select>
            </a-form-item>
          </a-col>
          <a-col :md="8" :sm="24">
            <span class="table-page-search-submitButtons" >
                <!-- :style="advanced && { float: 'right', overflow: 'hidden' } || {} " -->
              <a-button type="primary" @click="getDataList">查询</a-button>
              <a-button style="margin-left: 8px" @click="() => queryParam = {}">重置</a-button>
            </span>
          </a-col>
        </a-row>
      </a-form>
    </div>

    <div class="table-operator">
      <a-button type="primary" icon="plus" @click="$refs.editModal.add()">新建</a-button>
    </div>

    <a-table :dataSource="tableList" :pagination="pagination" @change="handleTableChange" :loading="loading" rowKey="id">
      
        <a-table-column title="ParentId" dataIndex="parentId" />
        <a-table-column title="名称" dataIndex="name" />
        <a-table-column title="图片" dataIndex="iconId" />
        <a-table-column title="类型" dataIndex="typeId" />
        <a-table-column title="自定义名称" dataIndex="diyName" />
        <a-table-column title="排序" dataIndex="sort" />
        <a-table-column title="分页大小" dataIndex="pageSize" />
          <a-table-column title="是否可投稿" dataIndex="isContribute">
            <template slot-scope="isContribute">
              <span>
                <a-tag v-if="isContribute" color="blue">是</a-tag>
                <a-tag v-else color="orange">否</a-tag>
              </span>
            </template>
          </a-table-column>
          <a-table-column title="导航显示" dataIndex="isNav">
            <template slot-scope="isNav">
              <span>
                <a-tag v-if="isNav" color="blue">是</a-tag>
                <a-tag v-else color="orange">否</a-tag>
              </span>
            </template>
          </a-table-column>
          <a-table-column title="状态" dataIndex="status">
            <template slot-scope="status">
              <span>
                <a-tag v-if="status" color="blue">是</a-tag>
                <a-tag v-else color="orange">否</a-tag>
              </span>
            </template>
          </a-table-column>
      
      <a-table-column title="操作" key="action">
      <template slot-scope="text, record">
        <span>
          <a @click="handleDetail(record.id)">详情</a>
          <a-divider type="vertical" />
          <a @click="handleEdit(record.id)">编辑</a>
          <a-divider type="vertical" />
              <a-popconfirm title="确定要删除这行数据吗?" placement="topLeft" @confirm="handleDel(record.id)">
                <template slot="title">
                  <p>取消</p>
                  <p>确定</p>
                </template>
                <a>删除</a>
              </a-popconfirm>
        </span>
      </template>
    </a-table-column>
    </a-table>

    <edit-form ref="editModal" :afterSubmit="handleOk" />
    <detail-form ref="detailModal" />
  </a-card>
</template>

<script>
import moment from 'moment'
import EditForm from './edit'
import DetailForm from './detail'
import { axios } from '@/utils/request'

export default {
  name: 'department',
  components: {
    EditForm,
    DetailForm
  },
  data () {
    return {
      tableList:[],
      // 查询参数
      queryParam: {name:"",page:1},
      pagination:{total:1,pageSize:20},
      loading : true
    }
  },
  created () {
    
  },
  mounted() {
    this.getDataList()
  },
  methods: {
    getDataList(){
      this.loading = true;
      axios.get("api/Column",{params : this.queryParam}).then(res=>{
        const {data,totalCount} = res.data;
        this.tableList = data;
        this.pagination.total = totalCount;
        this.loading = false;
      }).catch(()=>{
        this.loading = false;
      });
    },
    handleOk(){
      this.getDataList()
    },
    handleTableChange(pagination){
      this.queryParam.page= pagination.current;
      this.getDataList();
    },
    handleEdit(id) {
      this.$refs.editModal.edit(id)
    },
    handleDetail(id) {
      this.$refs.detailModal.detail(id)
    },
    handleDel(id){
        axios.delete('api/Column/' + id).then(res => {
          this.$message.info(`删除成功`);
          this.getDataList();
        })
    }
  }
}
</script>

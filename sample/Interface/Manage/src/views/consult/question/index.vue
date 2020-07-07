

<template>
  <a-card :bordered="false">
    <div class="table-page-search-wrapper">
      <a-form layout="inline">
        <a-row :gutter="48">
            
          <a-col :md="8" :sm="24">
            <a-form-item label="标识">
              <a-input v-model="queryParam.doctorId" placeholder=""/>
            </a-form-item>
          </a-col>
          <a-col :md="8" :sm="24">
            <a-form-item label="会员标识">
              <a-input v-model="queryParam.memberId" placeholder=""/>
            </a-form-item>
          </a-col>
          <a-col :md="8" :sm="24">
            <a-form-item label="年龄">
              <a-select v-model="queryParam.age" placeholder="请选择" default-value="">
                <a-select-option value="">全部</a-select-option>
                <a-select-option value="true">是</a-select-option>
                <a-select-option value="false">否</a-select-option>
              </a-select>
            </a-form-item>
          </a-col>
          <a-col :md="8" :sm="24">
            <a-form-item label="性别">
              <a-input v-model="queryParam.sexId" placeholder=""/>
            </a-form-item>
          </a-col>
          <a-col :md="8" :sm="24">
            <a-form-item label="标题">
              <a-input v-model="queryParam.title" placeholder=""/>
            </a-form-item>
          </a-col>
          <a-col :md="8" :sm="24">
            <a-form-item label="描述">
              <a-input v-model="queryParam.content" placeholder=""/>
            </a-form-item>
          </a-col>
          <a-col :md="8" :sm="24">
            <a-form-item label="图片">
              <a-input v-model="queryParam.imageId" placeholder=""/>
            </a-form-item>
          </a-col>
          <a-col :md="8" :sm="24">
            <a-form-item label="是否关闭">
              <a-select v-model="queryParam.isClose" placeholder="请选择" default-value="">
                <a-select-option value="">全部</a-select-option>
                <a-select-option value="true">是</a-select-option>
                <a-select-option value="false">否</a-select-option>
              </a-select>
            </a-form-item>
          </a-col>
          <a-col :md="8" :sm="24">
            <a-form-item label="评论标识">
              <a-input v-model="queryParam.commentId" placeholder=""/>
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
      
        <a-table-column title="标识" dataIndex="doctorId" />
        <a-table-column title="会员标识" dataIndex="memberId" />
        <a-table-column title="年龄" dataIndex="age" />
        <a-table-column title="性别" dataIndex="sexId" />
        <a-table-column title="标题" dataIndex="title" />
        <a-table-column title="描述" dataIndex="content" />
        <a-table-column title="图片" dataIndex="imageId" />
          <a-table-column title="是否关闭" dataIndex="isClose">
            <template slot-scope="isClose">
              <span>
                <a-tag v-if="isClose" color="blue">是</a-tag>
                <a-tag v-else color="orange">否</a-tag>
              </span>
            </template>
          </a-table-column>
        <a-table-column title="评论标识" dataIndex="commentId" />
      
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
      axios.get("Question",{params : this.queryParam}).then(res=>{
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
        axios.delete('Question/' + id).then(res => {
          this.$message.info(`删除成功`);
          this.getDataList();
        })
    }
  }
}
</script>



<template>
  <a-card :bordered="false">
    <div class="table-page-search-wrapper">
      <a-form layout="inline">
        <a-row :gutter="48">
            
          <a-col :md="8" :sm="24">
            <a-form-item label="昵称">
              <a-input v-model="queryParam.nickName" placeholder=""/>
            </a-form-item>
          </a-col>
          <a-col :md="8" :sm="24">
            <a-form-item label="性别">
              <a-select v-model="queryParam.sex" placeholder="请选择" default-value="">
                <a-select-option value="">全部</a-select-option>
                <a-select-option value="true">是</a-select-option>
                <a-select-option value="false">否</a-select-option>
              </a-select>
            </a-form-item>
          </a-col>
          <a-col :md="8" :sm="24">
            <a-form-item label="头像">
              <a-input v-model="queryParam.headImgId" placeholder=""/>
            </a-form-item>
          </a-col>
          <a-col :md="8" :sm="24">
            <a-form-item label="微信用户标识">
              <a-input v-model="queryParam.openId" placeholder=""/>
            </a-form-item>
          </a-col>
          <a-col :md="8" :sm="24">
            <a-form-item label="微信统一标识">
              <a-input v-model="queryParam.unionid" placeholder=""/>
            </a-form-item>
          </a-col>
          <a-col :md="8" :sm="24">
            <a-form-item label="姓名">
              <a-input v-model="queryParam.fullName" placeholder=""/>
            </a-form-item>
          </a-col>
          <a-col :md="8" :sm="24">
            <a-form-item label="手机号">
              <a-input v-model="queryParam.phoneNumber" placeholder=""/>
            </a-form-item>
          </a-col>
          <a-col :md="8" :sm="24">
            <a-form-item label="生日">
              <a-input v-model="queryParam.birthday" placeholder=""/>
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
      
        <a-table-column title="昵称" dataIndex="nickName" />
          <a-table-column title="性别" dataIndex="sex">
            <template slot-scope="sex">
              <span>
                <a-tag v-if="sex" color="blue">是</a-tag>
                <a-tag v-else color="orange">否</a-tag>
              </span>
            </template>
          </a-table-column>
        <!-- <a-table-column title="头像" dataIndex="headImgId" /> -->
        <a-table-column title="头像" dataIndex="headImgSrc">
          <template slot-scope="headImgSrc">
            <a-avatar :src="headImgSrc" shape="square" />
          </template>
        </a-table-column>
        <a-table-column title="微信用户标识" dataIndex="openId" />
        <a-table-column title="微信统一标识" dataIndex="unionid" />
        <a-table-column title="姓名" dataIndex="fullName" />
        <a-table-column title="手机号" dataIndex="phoneNumber" />
        <a-table-column title="生日" dataIndex="birthday" />
      
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
      axios.get("Member",{params : this.queryParam}).then(res=>{
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
        axios.delete('Member/' + id).then(res => {
          this.$message.info(`删除成功`);
          this.getDataList();
        })
    }
  }
}
</script>

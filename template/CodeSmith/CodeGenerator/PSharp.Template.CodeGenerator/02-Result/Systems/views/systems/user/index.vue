

<template>
  <a-card :bordered="false">
    <div class="table-page-search-wrapper">
      <a-form layout="inline">
        <a-row :gutter="48">
            
          <a-col :md="8" :sm="24">
            <a-form-item label="邮箱已确认">
              <a-select v-model="queryParam.emailConfirmed" placeholder="请选择" default-value="">
                <a-select-option value="">全部</a-select-option>
                <a-select-option value="true">是</a-select-option>
                <a-select-option value="false">否</a-select-option>
              </a-select>
            </a-form-item>
          </a-col>
          <a-col :md="8" :sm="24">
            <a-form-item label="手机已确认">
              <a-select v-model="queryParam.phoneNumberConfirmed" placeholder="请选择" default-value="">
                <a-select-option value="">全部</a-select-option>
                <a-select-option value="true">是</a-select-option>
                <a-select-option value="false">否</a-select-option>
              </a-select>
            </a-form-item>
          </a-col>
          <a-col :md="8" :sm="24">
            <a-form-item label="启用锁定">
              <a-select v-model="queryParam.lockoutEnabled" placeholder="请选择" default-value="">
                <a-select-option value="">全部</a-select-option>
                <a-select-option value="true">是</a-select-option>
                <a-select-option value="false">否</a-select-option>
              </a-select>
            </a-form-item>
          </a-col>
          <a-col :md="8" :sm="24">
            <a-form-item label="锁定截止">
              <a-input v-model="queryParam.lockoutEnd" placeholder=""/>
            </a-form-item>
          </a-col>
          <a-col :md="8" :sm="24">
            <a-form-item label="上次登陆时间">
              <a-input v-model="queryParam.lastLoginTime" placeholder=""/>
            </a-form-item>
          </a-col>
          <a-col :md="8" :sm="24">
            <a-form-item label="上次登陆Ip">
              <a-input v-model="queryParam.lastLoginIp" placeholder=""/>
            </a-form-item>
          </a-col>
          <a-col :md="8" :sm="24">
            <a-form-item label="本次登陆时间">
              <a-input v-model="queryParam.currentLoginTime" placeholder=""/>
            </a-form-item>
          </a-col>
          <a-col :md="8" :sm="24">
            <a-form-item label="本次登陆Ip">
              <a-input v-model="queryParam.currentLoginIp" placeholder=""/>
            </a-form-item>
          </a-col>
          <a-col :md="8" :sm="24">
            <a-form-item label="启用两阶段认证">
              <a-select v-model="queryParam.twoFactorEnabled" placeholder="请选择" default-value="">
                <a-select-option value="">全部</a-select-option>
                <a-select-option value="true">是</a-select-option>
                <a-select-option value="false">否</a-select-option>
              </a-select>
            </a-form-item>
          </a-col>
          <a-col :md="8" :sm="24">
            <a-form-item label="启用">
              <a-select v-model="queryParam.enabled" placeholder="请选择" default-value="">
                <a-select-option value="">全部</a-select-option>
                <a-select-option value="true">是</a-select-option>
                <a-select-option value="false">否</a-select-option>
              </a-select>
            </a-form-item>
          </a-col>
          <a-col :md="8" :sm="24">
            <a-form-item label="冻结时间">
              <a-input v-model="queryParam.disabledTime" placeholder=""/>
            </a-form-item>
          </a-col>
          <a-col :md="8" :sm="24">
            <a-form-item label="注册Ip">
              <a-input v-model="queryParam.registerIp" placeholder=""/>
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
      
          <a-table-column title="邮箱已确认" dataIndex="emailConfirmed">
            <template slot-scope="emailConfirmed">
              <span>
                <a-tag v-if="emailConfirmed" color="blue">是</a-tag>
                <a-tag v-else color="orange">否</a-tag>
              </span>
            </template>
          </a-table-column>
          <a-table-column title="手机已确认" dataIndex="phoneNumberConfirmed">
            <template slot-scope="phoneNumberConfirmed">
              <span>
                <a-tag v-if="phoneNumberConfirmed" color="blue">是</a-tag>
                <a-tag v-else color="orange">否</a-tag>
              </span>
            </template>
          </a-table-column>
          <a-table-column title="启用锁定" dataIndex="lockoutEnabled">
            <template slot-scope="lockoutEnabled">
              <span>
                <a-tag v-if="lockoutEnabled" color="blue">是</a-tag>
                <a-tag v-else color="orange">否</a-tag>
              </span>
            </template>
          </a-table-column>
        <a-table-column title="锁定截止" dataIndex="lockoutEnd" />
        <a-table-column title="上次登陆时间" dataIndex="lastLoginTime" />
        <a-table-column title="上次登陆Ip" dataIndex="lastLoginIp" />
        <a-table-column title="本次登陆时间" dataIndex="currentLoginTime" />
        <a-table-column title="本次登陆Ip" dataIndex="currentLoginIp" />
        <a-table-column title="登陆次数" dataIndex="loginCount" />
        <a-table-column title="登陆失败次数" dataIndex="accessFailedCount" />
          <a-table-column title="启用两阶段认证" dataIndex="twoFactorEnabled">
            <template slot-scope="twoFactorEnabled">
              <span>
                <a-tag v-if="twoFactorEnabled" color="blue">是</a-tag>
                <a-tag v-else color="orange">否</a-tag>
              </span>
            </template>
          </a-table-column>
          <a-table-column title="启用" dataIndex="enabled">
            <template slot-scope="enabled">
              <span>
                <a-tag v-if="enabled" color="blue">是</a-tag>
                <a-tag v-else color="orange">否</a-tag>
              </span>
            </template>
          </a-table-column>
        <a-table-column title="冻结时间" dataIndex="disabledTime" />
        <a-table-column title="注册Ip" dataIndex="registerIp" />
      
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
      axios.get("api/User",{params : this.queryParam}).then(res=>{
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
        axios.delete('api/User/' + id).then(res => {
          this.$message.info(`删除成功`);
          this.getDataList();
        })
    }
  }
}
</script>

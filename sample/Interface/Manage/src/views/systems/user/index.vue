<template>
  <a-card :bordered="false">
    <div class="table-page-search-wrapper">
      <a-form layout="inline">
        <a-row :gutter="48">
          <a-col :md="8" :sm="24">
            <a-form-item label="用户名">
              <a-input v-model="queryParam.userName" placeholder="请输入用户名" />
            </a-form-item>
          </a-col>
          <a-col :md="8" :sm="24">
            <a-form-item label="昵称">
              <a-input v-model="queryParam.nickName" placeholder="请输入昵称" />
            </a-form-item>
          </a-col>
          <a-col :md="8" :sm="24">
            <a-form-item label="姓名">
              <a-input v-model="queryParam.name" placeholder="请输入姓名" />
            </a-form-item>
          </a-col>
          <a-col :md="8" :sm="24">
            <a-form-item label="手机号">
              <a-input v-model="queryParam.phoneNumber" placeholder="请输入手机号" />
            </a-form-item>
          </a-col>
          <a-col :md="8" :sm="24">
            <a-form-item label="启用">
              <a-select v-model="queryParam.enabled" placeholder="请选择是否启用" defaultValue="1">
                <a-select-option value="all">全部</a-select-option>
                <a-select-option value="true">是</a-select-option>
                <a-select-option value="false">否</a-select-option>
              </a-select>
            </a-form-item>
          </a-col>
          <a-col :md="8" :sm="24">
            <span class="table-page-search-submitButtons">
              <a-button type="primary" @click="handleQuery">查询</a-button>
              <a-button style="margin-left: 8px" @click="handleReset">重置</a-button>
            </span>
          </a-col>
        </a-row>
      </a-form>
    </div>

    <div class="table-operator">
      <a-button type="primary" icon="plus" @click="handleAdd">新建</a-button>
    </div>

    <a-table
      :dataSource="tableList"
      :pagination="pagination"
      @change="handleTableChange"
      rowKey="id"
    >
      <!-- <a-table-column title="序号" dataIndex="sortId" /> -->
      <a-table-column title="用户名" dataIndex="userName" />
      <a-table-column title="手机号" dataIndex="phoneNumber" />
      <a-table-column title="邮箱" dataIndex="email" />
      <a-table-column title="启用" dataIndex="enabled">
        <template slot-scope="enabled">
          <span>
            <a-tag v-if="enabled" color="blue">是</a-tag>
            <a-tag v-else color="orange">否</a-tag>
          </span>
        </template>
      </a-table-column>
      <!-- <a-table-column title="登录次数" dataIndex="loginCount" /> -->
      <!-- <a-table-column title="创建时间" dataIndex="creationTime" /> -->
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
            <a-divider type="vertical" />
            <a @click="handleDistribute(record.id)">分配</a>
          </span>
        </template>
      </a-table-column>
    </a-table>
    <edit-form ref="editModal" :afterSubmit="handleQuery" />
    <detail-form ref="detailModal" />
    <distribute-form ref="distributeModal" />
  </a-card>
</template>

<script>
import moment from 'moment'
import EditForm from './edit'
import DetailForm from './detail'
import DistributeForm from './distribute'
import { axios } from '@/utils/request'

export default {
  name: 'department',
  components: {
    EditForm,
    DistributeForm,
    DetailForm
  },
  data() {
    return {
      loading: true,
      tableList: [],
      allData: { id: 'all', name: '全部' },
      pagination: {
        total: 1,
        pageSize: 10,
        showSizeChanger: true,
        current: 1
      },
      queryParam: {
        page: 0,
        pageSize: 0
      }
    }
  },
  created() {
    this.queryParam.page = this.pagination.current
    this.queryParam.pageSize = this.pagination.pageSize
    this.getDataList()
  },
  methods: {
    getDataList() {
      this.loading = true
      let params = Object.assign({}, this.queryParam)
      for (let i in params) {
        params[i] == 'all' && (params[i] = '')
        if (params[i] == '') {
          delete params[i]
        }
      }
      axios
        .get('User', { params })
        .then(res => {
          this.pagination.current = res.data.page
          this.pagination.pageSize = res.data.pageSize
          this.pagination.total = res.data.totalCount
          this.tableList = res.data.data
          this.loading = false
        })
        .catch(() => {
          this.loading = false
        })
    },
    // 查询
    handleQuery() {
      this.getDataList()
    },
    // 重置
    handleReset() {
      this.queryParam = {}
      this.queryParam.page = this.pagination.current
      this.queryParam.pageSize = this.pagination.pageSize
      this.handleQuery()
    },
    // 分页函数
    handleTableChange(res) {
      this.queryParam.page = res.current
      this.queryParam.pageSize = res.pageSize
      this.getDataList()
    },
    // 添加
    handleAdd() {
      this.$refs.editModal.add()
    },
    // 编辑
    handleEdit(id) {
      this.$refs.editModal.edit(id)
    },
    // 分配
    handleDistribute(id) {
      this.$refs.distributeModal.distribute(id)
    },
    // 详情
    handleDetail(id) {
      this.$refs.detailModal.detail(id)
    },
    // 删除
    handleDel(id) {
      axios.delete('User/' + id).then(res => {
        this.$message.info(`删除成功`)
        this.getDataList()
      })
    }
  }
}
</script>

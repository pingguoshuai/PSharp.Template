

<template>
  <a-card :bordered="false">
    <div class="table-page-search-wrapper">
      <a-form layout="inline">
        <a-row :gutter="48">
          <a-col :md="8" :sm="24">
            <a-form-item label="接口名称">
              <a-input v-model="queryParam.name" placeholder="请输入接口名称" />
            </a-form-item>
          </a-col>
          <a-col :md="8" :sm="24">
            <a-form-item label="模块编码">
              <a-input v-model="queryParam.moduleCode" placeholder="请输入模块编码" />
            </a-form-item>
          </a-col>
          <a-col :md="8" :sm="24">
            <a-form-item label="控制器">
              <a-input v-model="queryParam.contorller" placeholder="请输入控制器" />
            </a-form-item>
          </a-col>
          <a-col :md="8" :sm="24">
            <a-form-item label="操作">
              <a-input v-model="queryParam.action" placeholder="请输入操作" />
            </a-form-item>
          </a-col>
          <!-- <a-col :md="8" :sm="24">
            <a-form-item label="请求方式">
              <a-select v-model="queryParam.httpMethod" placeholder="请选择请求方式" defaultValue="1">
                  <a-select-option value="all">全部</a-select-option>
                  <a-select-option value="get">get</a-select-option>
                  <a-select-option value="put">put</a-select-option>
                  <a-select-option value="post">post</a-select-option>
                  <a-select-option value="delete">delete</a-select-option>
              </a-select>
            </a-form-item>
          </a-col> -->
          <a-col :md="8" :sm="24">
            <a-form-item label="唯一编码">
              <a-input v-model="queryParam.code" placeholder="请输入唯一编码" />
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
      <a-button type="primary" icon="plus" @click="handleSync">同步</a-button>
    </div>

    <a-table
      :dataSource="tableList"
      :pagination="pagination"
      @change="handleTableChange"
      rowKey="id"
    >
      <a-table-column title="名称" dataIndex="name" />
      <a-table-column title="模块编码" dataIndex="moduleCode" />
      <a-table-column title="控制器" dataIndex="contorller" />
      <a-table-column title="操作" dataIndex="action" />
      <a-table-column title="路由" dataIndex="route" />
      <a-table-column title="请求方式" dataIndex="httpMethod" />
      <a-table-column title="唯一编码" dataIndex="code" />

      <a-table-column title="操作" key="action3">
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

    <edit-form ref="editModal" :afterSubmit="handleQuery" />
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
        .get('Interface', { params })
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
    // 详情
    handleDetail(id) {
      this.$refs.detailModal.detail(id)
    },
    // 删除
    handleDel(id) {
      axios.delete('Interface/' + id).then(res => {
        this.$message.info(`删除成功`)
        this.getDataList()
      })
    },
    handleSync() {
      axios.post('Interface/Sync').then(res => {
        this.getDataList()
      })
    }
  }
}
</script>

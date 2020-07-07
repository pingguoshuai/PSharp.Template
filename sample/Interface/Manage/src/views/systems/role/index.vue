

<template>
  <a-card :bordered="false">
    <div class="table-page-search-wrapper">
      <a-form layout="inline">
        <a-row :gutter="48">
          <a-col :md="8" :sm="24">
            <a-form-item label="角色编码">
              <a-input v-model="queryParam.code" placeholder="请输入角色编码" />
            </a-form-item>
          </a-col>
          <a-col :md="8" :sm="24">
            <a-form-item label="角色名称">
              <a-input v-model="queryParam.name" placeholder="请输入角色名称" />
            </a-form-item>
          </a-col>
          <a-col :md="8" :sm="24">
            <a-form-item label="角色拼音">
              <a-input v-model="queryParam.pinYin" placeholder="请输入角色拼音" />
            </a-form-item>
          </a-col>
          <a-col :md="8" :sm="24">
            <a-form-item label="是否启用">
              <a-select v-model="queryParam.enabled" placeholder="请选择是否启用" default-value="1">
                <a-select-option value="all">全部</a-select-option>
                <a-select-option value="true">是</a-select-option>
                <a-select-option value="false">否</a-select-option>
              </a-select>
            </a-form-item>
          </a-col>
          <a-col :md="8" :sm="24">
            <a-form-item label="是否为管理员">
              <a-select v-model="queryParam.isAdmin" placeholder="请选择是否为管理员" default-value="1">
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
      childrenColumnName=""
    >
      <a-table-column title="序号" dataIndex="sortId" />
      <a-table-column title="角色编码" dataIndex="code" />
      <a-table-column title="角色名称" dataIndex="name" />
      <a-table-column title="管理员" dataIndex="isAdmin">
        <template slot-scope="isAdmin">
          <span>
            <a-tag v-if="isAdmin" color="blue">是</a-tag>
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
      <a-table-column title="操作" key="action">
        <template slot-scope="text, record">
          <span>
            <a-button type="primary" shape="circle" icon="safety" @click="handlePower(record.id)" />
            <a-divider type="vertical" />
            <a-button type="primary" shape="circle" icon="edit" @click="handleEdit(record.id)" />
            <a-divider type="vertical" />
            <a-popconfirm title="确定要删除这行数据吗?" placement="topLeft" @confirm="handleDel(record.id)">
              <template slot="title">
                <p>取消</p>
                <p>确定</p>
              </template>
              <a-button type="danger" shape="circle" icon="delete" />
            </a-popconfirm>
            <a-divider type="vertical" />
            <a-button type="default" shape="circle" icon="eye" @click="handleDetail(record.id)" />
          </span>
        </template>
      </a-table-column>
    </a-table>

    <edit-form ref="editModal" :afterSubmit="handleQuery" />
    <detail-form ref="detailModal" />
    <power-form ref="powerModal" />
  </a-card>
</template>

<script>
import moment from 'moment'
import EditForm from './edit'
import DetailForm from './detail'
import PowerForm from './power'
import { axios } from '@/utils/request'

export default {
  name: 'department',
  components: {
    EditForm,
    DetailForm,
    PowerForm
  },
  data() {
    return {
      loading: true,
      tableList: [],
      pagination: {
        total: 1,
        pageSize: 10,
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
        .get('Role', { params })
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
    // 权限
    handlePower(id) {
      this.$refs.powerModal.power(id)
    },
    // 详情
    handleDetail(id) {
      this.$refs.detailModal.detail(id)
    },
    // 删除
    handleDel(id) {
      axios.delete('Role/' + id).then(res => {
        this.$message.info(`删除成功`)
        this.getDataList()
      })
    }
  }
}
</script>

<style>
td button.ant-btn {
  line-height: normal;
}
</style>

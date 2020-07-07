<template>
  <a-card :bordered="false">
    <div class="table-page-search-wrapper">
      <a-form layout="inline">
        <a-row :gutter="48">
          <!-- <a-col :md="8" :sm="24">
            <a-form-item label="菜单名称">
              <a-input v-model="queryParam.name" placeholder="请输入菜单名称" />
            </a-form-item>
          </a-col> -->
          <!-- <a-col :md="8" :sm="24">
            <a-form-item label="资源类型">
              <a-input v-model="queryParam.type" placeholder="请输入资源类型" />
            </a-form-item>
          </a-col> -->
          <a-col :md="8" :sm="24">
            <a-form-item label="启用">
              <a-select v-model="queryParam.enabled" placeholder="请选择是否启用" default-value>
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

    <a-spin :spinning="loading">
      <a-row style="border: 1px solid #f0f2f5;background: #f0f2f5">
        <a-col :xs="0" :md="4">
          <a-menu
            v-if="queryParam.applicationId"
            mode="inline"
            :defaultSelectedKeys="[queryParam.applicationId]"
            @select="selectMenu"
          >
            <a-menu-item v-for="item of applicationList" :key="item.id">
              {{ item.name }}
            </a-menu-item>
          </a-menu>
        </a-col>
        <a-col :xs="24" :md="0">
          <a-menu
            v-if="queryParam.applicationId"
            mode="horizontal"
            :defaultSelectedKeys="[queryParam.applicationId]"
            @select="selectMenu"
          >
            <a-menu-item v-for="item of applicationList" :key="item.id">
              {{ item.name }}
            </a-menu-item>
          </a-menu>
        </a-col>
        <a-col :xs="24" :md="20" style="background: #fff">
          <a-table v-if="!loading" :dataSource="tableList" :defaultExpandAllRows="true" :pagination="false" rowKey="id">
            <a-table-column title="菜单名称" data-index="name" />
            <a-table-column title="路由名称" data-index="routeName" />
            <a-table-column title="资源类型" data-index="typeText" />
            <a-table-column title="启用" data-index="enabled">
              <template slot-scope="enabled">
                <span>
                  <a-tag v-if="enabled" color="blue">是</a-tag>
                  <a-tag v-else color="orange">否</a-tag>
                </span>
              </template>
            </a-table-column>
            <a-table-column title="是否隐藏" data-index="isHide">
              <template slot-scope="isHide">
                <span>
                  <a-tag v-if="isHide" color="blue">是</a-tag>
                  <a-tag v-else color="orange">否</a-tag>
                </span>
              </template>
            </a-table-column>
            <a-table-column title="接口" data-index="interfaceCode" />
            <a-table-column title="图标" data-index="iconId" />

            <a-table-column title="操作" key="action" :defaultExpandAllRows="Expanded">
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
        </a-col>
      </a-row>
    </a-spin>
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
      Expanded: false,
      tableList: [],
      applicationList: [],
      allData: { id: 'all', name: '全部' },
      queryParam: {}
    }
  },
  created() {
    this.getApplicationList()
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
        .get('Resource', { params })
        .then(res => {
          this.tableList = res.data
          this.loading = false
          this.Expanded = true
        })
        .catch(() => {
          this.loading = false
        })
    },
    getApplicationList() {
      axios.get('Application/all').then(res => {
        this.queryParam.applicationId = res.data[0].id
        this.applicationList = res.data
        this.getDataList()
      })
    },
    selectMenu(res) {
      this.queryParam.applicationId = res.key
      this.getDataList()
    },
    // 查询
    handleQuery() {
      this.getDataList()
    },
    // 重置
    handleReset() {
      this.queryParam = {}
      this.queryParam.applicationId = this.applicationList[0].id
      this.handleQuery()
    },
    // 添加
    handleAdd() {
      this.$refs.editModal.add(this.queryParam.applicationId)
    },
    // 编辑
    handleEdit(id) {
      this.$refs.editModal.edit(id, this.queryParam.applicationId)
    },
    // 详情
    handleDetail(id) {
      this.$refs.detailModal.detail(id)
    },
    // 删除
    handleDel(id) {
      axios.delete('Resource/' + id).then(res => {
        this.$message.info(`删除成功`)
        this.getDataList()
      })
    }
  }
}
</script>

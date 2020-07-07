<template>
  <a-card :bordered="false">
    <div class="table-operator">
      <a-button type="primary" icon="plus" @click="handleClear">清空缓存</a-button>
    </div>
    <a-table :dataSource="tableList" :pagination="false" rowKey="text">
      <a-table-column title="缓存名称" dataIndex="text" />
      <a-table-column title="缓存值" dataIndex="value" />
      <a-table-column title="操作" key="action">
        <template slot-scope="text, record">
          <a-popconfirm title="确定要删除这项缓存吗?" placement="topLeft" @confirm="handleRemove(record.value)">
            <template slot="title">
              <p>取消</p>
              <p>确定</p>
            </template>
            <a>删除缓存</a>
          </a-popconfirm>
        </template>
      </a-table-column>
    </a-table>
  </a-card>
</template>

<script>
import moment from 'moment'
import { axios } from '@/utils/request'

export default {
  name: 'department',
  data() {
    return {
      loading: true,
      tableList: []
    }
  },
  created() {
    this.getDataList()
  },
  methods: {
    getDataList() {
      this.loading = true
      axios
        .get('Cache')
        .then(res => {
          this.tableList = res.data
          this.loading = false
        })
        .catch(() => {
          this.loading = false
        })
    },
    // 清空
    handleClear() {
      axios.post('Cache/Clear').then(res => {
        this.$message.info(`清空成功`)
        this.getDataList()
      })
    },
    // 删除
    handleRemove(key) {
      axios.post('Cache/Remove?key=' + key).then(res => {
        this.$message.info(`删除成功`)
        this.getDataList()
      })
    }
  }
}
</script>

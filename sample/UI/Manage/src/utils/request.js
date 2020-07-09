import Vue from 'vue'
import axios from 'axios'
import store from '@/store'
import notification from 'ant-design-vue/es/notification'
import { VueAxios } from './axios'
import { ACCESS_TOKEN } from '@/store/mutation-types'

// 创建 axios 实例
const service = axios.create({
  baseURL: process.env.VUE_APP_API_BASE_URL, // api base_url
  timeout: 30000 // 请求超时时间
})

const err = (error) => {
  if (error.response) {
    const data = error.response.data
    const token = Vue.ls.get(ACCESS_TOKEN)
    // const token = window.sessionStorage.getItem('token')
    if (error.response.status === 401 && !(data.result && data.result.isLogin)) {
      notification.error({
        message: 'Unauthorized',
        description: 'Authorization verification failed'
      })
      store.dispatch('Logout').then(() => {
        setTimeout(() => {
          window.location.href = '/user/login';
        }, 1500)
      })
      if (token) {
        store.dispatch('Logout').then(() => {
          setTimeout(() => {
            window.location.href = '/user/login';
          }, 1500)
        })
      }
    }else{
      
      if (error.response.status === 403) {
        notification.error({
          message: 'Forbidden',
          description: data.message
        })
      }else if(error.response.status === 503){
        notification.error({
          message: 'Service Unavailable',
          description: '服务未启动'
        })
      }
    }
  }
  return Promise.reject(error)
}

// request interceptor
service.interceptors.request.use(config => {
  store.state.loadding = true;
  const token = Vue.ls.get(ACCESS_TOKEN)
  
  if (token) {
    config.headers['Authorization'] = "Bearer "+token // 让每个请求携带自定义 token 请根据实际情况自行修改
  }
  return config
}, err)

// response interceptor
service.interceptors.response.use((response) => {
  store.state.loadding = false;
  const {data} = response;
  if(data.code != 1){
    notification.error({
      message: data.message
    })
    return Promise.reject(response)
  }
  return response.data
}, err)

const installer = {
  vm: {},
  install (Vue) {
    Vue.use(VueAxios, service)
  }
}

export {
  installer as VueAxios,
  service as axios
}

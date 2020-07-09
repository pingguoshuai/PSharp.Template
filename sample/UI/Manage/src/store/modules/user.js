import Vue from 'vue'
import { login, getInfo, logout } from '@/api/login'
import store from '@/store'
import { ACCESS_TOKEN } from '@/store/mutation-types'
import { welcome } from '@/utils/util'

const user = {
  state: {
    token: '',
    name: '',
    welcome: '',
    avatar: '',
    roles: [],
    info: {},
    menus:[]
  },

  mutations: {
    SET_TOKEN: (state, token) => {
      // console.log(token)
      state.token = token
    },
    SET_NAME: (state, { name, welcome }) => {
      state.name = name
      state.welcome = welcome
    },
    SET_AVATAR: (state, avatar) => {
      state.avatar = avatar
    },
    SET_ROLES: (state, roles) => {
      state.roles = roles
    },
    SET_INFO: (state, info) => {
      state.info = info
    },
    SET_MENUS: (state, menus) => {
      state.menus = menus
    }
  },

  actions: {
    // 登录
    Login ({ commit }, userInfo) {
      return new Promise((resolve, reject) => {
        login(userInfo).then(response => {
          const result = response.data
          window.sessionStorage.setItem('token', result.token)
          Vue.ls.set(ACCESS_TOKEN, result.token, 7 * 24 * 60 * 60 * 1000)
          commit('SET_TOKEN', result.token)
          resolve()
        }).catch(error => {
          reject(error)
        })
      })
    },

    // 获取用户信息
    GetInfo ({ commit }) {
      return new Promise((resolve, reject) => {
        getInfo().then(response => {
          const result = response.data
          const {menus, roles, info} = result

          commit('SET_MENUS', menus)
          commit('SET_ROLES', roles)
          commit('SET_INFO', info)

          // commit('SET_NAME', { name: result.name, welcome: welcome() })
          // commit('SET_AVATAR', result.avatar)

          resolve(response)
        }).catch(error => {
          reject(error)
        })
      })
    },

    // 登出
    Logout ({ commit, state }) {
      return new Promise((resolve) => {
        // logout(state.token).then(() => {
        //   resolve()
        // }).catch(() => {
        //   resolve()
        // }).finally(() => {
          commit('SET_TOKEN', '')
          commit('SET_ROLES', [])
          commit('SET_INFO', {})
          store.state.inited = false

          Vue.ls.remove(ACCESS_TOKEN)
          // window.sessionStorage.removeItem(ACCESS_TOKEN)
        //})
        resolve()
      })
    }

  }
}

export default user

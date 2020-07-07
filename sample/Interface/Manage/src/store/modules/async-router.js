/**
 * 向后端请求用户的菜单，动态生成路由
 */
import { constantRouterMap,asyncRouterMap } from '@/config/router.config'
import { generatorDynamicRouter } from '@/router/generator-routers'

const permission = {
  state: {
    routers: constantRouterMap,
    addRouters: []
  },
  mutations: {
    SET_ROUTERS: (state, routers) => {
      state.addRouters = routers
      state.routers = constantRouterMap.concat(routers)
    }
  },
  actions: {
    GenerateRoutes ({ commit }, data) {
      const {menus,roles,info} = data
      return new Promise(resolve => {
        generatorDynamicRouter(menus).then(routers => {
          if(roles.includes('admin') || info.userName =='admin'){
            commit('SET_ROUTERS', asyncRouterMap)
          }else{
            commit('SET_ROUTERS', routers)
          }
          resolve()
        })
      })
    }
  }
}

export default permission

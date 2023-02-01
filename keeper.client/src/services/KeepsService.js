import { api } from "./AxiosService"
import { logger } from "../utils/Logger"
import { AppState } from "../AppState"

class KeepsService {


  async getKeeps() {
    try {
      const res = await api.get('api/keeps')
      logger.log('keeps', res.data)
      AppState.keeps = res.data

    } catch (error) {
      logger.error(error.message)
    }
  }

  async getProfileKeeps(userId) {
    const res = await api.get('account/keeps')
    logger.log(res.data)
    AppState.accountKeeps = res.data

  }

  async getOneKeep(keepId) {
    const res = await api.get('api/keeps/' + keepId)
    logger.log('getting keep', res.data)
    AppState.activeKeep = res.data
  }

  async createKeep(keepData) {
    const res = await api.post('api/keeps', keepData)
    logger.log(res.data)
    AppState.accountKeeps.push(res.data)
    return res.data
  }

  async deleteKeep(keepId) {
    const res = await api.delete('api/keeps/' + keepId)
    logger.log(res.data)
    AppState.accountKeeps = AppState.accountKeeps.filter(k => k.id != keepId)
  }


}



export const keepsService = new KeepsService()
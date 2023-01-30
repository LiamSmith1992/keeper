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
    const res = await api.get('api/profiles/' + userId + 'keeps')
    logger.log(res.data)
    AppState.keeps = res.data
  }
}



export const keepsService = new KeepsService()
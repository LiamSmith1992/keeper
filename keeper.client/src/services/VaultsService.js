import { AppState } from "../AppState"
import { api } from "./AxiosService"
import { logger } from "../utils/Logger"

class VaultsService {

  async getAccountVaults() {
    const res = await api.get('account/vaults')
    logger.log(res.data)
    AppState.vaults = res.data
  }


}



export const vaultsService = new VaultsService()
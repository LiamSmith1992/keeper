import { AppState } from "../AppState"
import { api } from "./AxiosService"
import { logger } from "../utils/Logger"

class VaultsService {

  async getAccountVaults() {
    const res = await api.get('account/vaults')
    logger.log(res.data)
    AppState.accountVaults = res.data
  }

  async getOneVault(vaultId) {
    const res = await api.get('api/vaults/' + vaultId)
    logger.log("one vault", res.data)
    AppState.activeVault = res.data
  }

  async getKeepsInVault(vaultId) {
    const res = await api.get('api/vaults/' + vaultId + '/keeps')
    logger.log(res.data)
    AppState.vaultKeeps = res.data
  }


}



export const vaultsService = new VaultsService()
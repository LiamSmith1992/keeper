import { AppState } from "../AppState"
import { api } from "./AxiosService"
import { logger } from "../utils/Logger"
import Pop from "../utils/Pop"

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

  async createVault(vaultData) {
    const res = await api.post('api/vaults', vaultData)
    logger.log(res.data)
    AppState.accountVaults.push(res.data)
    return res.data
  }

  async deleteVault(vaultId) {

    const res = await api.delete('api/vaults/' + vaultId)
    logger.log(res.data)
    Pop.toast('vault was deleted', "success")
    AppState.accountVaults = AppState.accountVaults.filter(v => v.id != vaultId)
  }




}



export const vaultsService = new VaultsService()
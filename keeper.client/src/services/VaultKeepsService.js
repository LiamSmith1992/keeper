import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import Pop from "../utils/Pop"
import { api } from "./AxiosService"

class VaultKeepsService {

  async createVaultKeep(body) {
    const res = await api.post('api/vaultKeeps', body)
    logger.log(res.data)
  }

  async deleteKeep(vaultKeepId) {
    const res = await api.delete('api/vaultKeeps/' + vaultKeepId)
    logger.log(res.data)
    Pop.toast("keep was removed from vault", "success")
    AppState.vaultKeeps = AppState.vaultKeeps.filter(v => v.vaultKeepId != vaultKeepId)
  }



}





export const vaultKeepsService = new VaultKeepsService()
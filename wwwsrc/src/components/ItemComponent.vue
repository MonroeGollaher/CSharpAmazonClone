<template>
  <div class="items-component col-3 shadow card rounded container-fluid mt-5">
    <img :src="item.image" class="img-fluid justify-content-center" />
    <div class="mt-4">
      <h3>{{ item.title }}</h3>
      <h4>${{ item.price }}</h4>
      <button @click="deleteItem(item.id)" class="btn bg-transparent text-danger">
        <i class="fas fa-times"></i>
      </button>
      <button class="btn bg-transparent text-primary" data-toggle="modal" :data-target="'#editModal' + item.id">
        <i class="far fa-edit"></i>
      </button>
      <button class="btn bg-transparent text-success">
        <i class="fas fa-list-ol"></i>
      </button>
    </div>
  </div>

  <!-- Modal -->
  <div class="modal fade"
       :id="'editModal' + item.id"
       tabindex="-1"
       role="dialog"
       aria-labelledby="exampleModalLabel"
       aria-hidden="true"
  >
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" id="exampleModalLabel">
            Edit your item
          </h5>
          <form @submit="editItem(state.editedItem, item.id)">
            <div class="form-group">
              <label for="itemTitle">Product title</label>
              <input type="text"
                     class="form-control"
                     id="itemTitle"
                     aria-describedby="itemTitle"
                     placeholder="What's your item called?"
                     v-model="state.editedItem.title"
              >
            </div>
            <div class="form-group">
              <label for="itemDescription">Description</label>
              <input type="text"
                     class="form-control"
                     id="itemDescription"
                     placeholder="How would your describe your product?"
                     v-model="state.editedItem.body"
              >
            </div>
            <div class="form-group">
              <label for="image">Image</label>
              <input type="text" class="form-control" placeholder="Picture" v-model="state.editedItem.image">
            </div>
            <div class="form-group">
              <label for="price">Price</label>
              <input type="number"
                     class="form-control"
                     id="itemPrice"
                     placeholder="How much does your item cost?"
                     v-model="state.editedItem.price"
              >
            </div>
            <div class="form-group">
              <label for="price">Sale Price</label>
              <input type="number"
                     class="form-control"
                     id="salePrice"
                     placeholder="If your item goes on sale, how much will it cost?"
                     v-model="state.editedItem.salePrice"
              >
            </div>
            <div class="form-group">
              <label for="itemQuantity">Quantity</label>
              <input type="number"
                     class="form-control"
                     id="itemQuantity"
                     placeholder="How many items do you have to sell?"
                     v-model="state.editedItem.quantity"
              >
            </div>
            <div class="form-group">
              <label for="image">Published?</label>
              <input class="ml-3" type="checkbox" v-model="state.editedItem.isAvailable">
            </div>
            <button type="submit" class="btn btn-primary mb-3">
              Edit Item
            </button>
          </form>
          <button type="button" class="close" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-secondary" data-dismiss="modal">
            Close
          </button>
          <button type="button" class="btn btn-primary">
            Save changes
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, reactive } from 'vue'
import { itemsService } from '../services/ItemsService'

export default {
  name: 'ItemsComponent',
  props: ['itemProp'],
  setup(props) {
    const state = reactive({
      editedItem: {

      }
    })
    return {
      item: computed(() => props.itemProp),
      deleteItem(id) {
        itemsService.deleteItem(id)
      },
      editItem(editedItem, id) {
        itemsService.editItem(state.editedItem, id)
      },
      state
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>
img{
  width: 275px;
  height: 275px;
  object-fit: cover;
}
</style>
